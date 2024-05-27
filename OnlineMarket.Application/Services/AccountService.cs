using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using OnlineMarket.Application.Common.Exceptions;
using OnlineMarket.Application.Common.Security;
using OnlineMarket.Application.Common.Validators;
using OnlineMarket.Application.DTOs.UserDTOs;
using OnlineMarket.Application.Interafces;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;
using System.Net;

namespace OnlineMarket.Application.Services;

public class AccountService(IUnitOfWork unitOfWork,
                            IAuthManager authManager,
                            IValidator<User> validator,
                            IMemoryCache cache,
                            IEmailService emailService)
    : IAccountService
{
    public IAuthManager _authManager = authManager;

    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<User> _validator = validator;
    private readonly IMemoryCache _cache = cache;
    private readonly IEmailService _emailService = emailService;

    public async Task CheckCodeAsync(string email, string code)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(email);
        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User with this email not found");

        var currentCode = _cache.TryGetValue(email, out var password);
        if (!currentCode)
            throw new StatusCodeException(HttpStatusCode.Conflict, "Code already expired!");

        if (code == null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is required");

        if (!code.Equals(password))
            throw new StatusCodeException(HttpStatusCode.Conflict, "Code is incorrected");

        user.IsVerified = true;
        await _unitOfWork.User.UpdateAsync(user);
    }

    public async Task<string> LoginAsync(LoginDto login)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(login.Email);
        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User with this email not found");

        if (!user.IsVerified)
            throw new StatusCodeException(HttpStatusCode.Unauthorized, "Unauthorized action!");

        if (user.Password != PasswordHasher.GetHash(login.Password))
            throw new StatusCodeException(HttpStatusCode.Conflict, "Password is incorrect");

        return _authManager.GenerateToken(user);
    }

    public async Task<bool> RegisterAsync(AddUserDto dto)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(dto.Email);
        if (user is not null)
            throw new StatusCodeException(HttpStatusCode.AlreadyReported, "User with this email already exists");

        var entity = (User)dto;
        var result = await _validator.ValidateAsync(entity);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        entity.Password = PasswordHasher.GetHash(dto.Password);
        await _unitOfWork.User.CreateAsync(entity);

        return true;
    }

    public async Task SendCodeAsync(string email)
    {
        var user = _unitOfWork.User.GetByEmailAsync(email);
        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User with this email not found");

        var code = GenerateCode();
        _cache.Set(email, code, TimeSpan.FromSeconds(60));

        await _emailService.SendMessageToEmailAsync(email, "Verification code", code);
    }

    public async Task UpdatePasswordAsync(string email, string newPassword)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(email);
        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User with this email not found");

        if (newPassword is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Password is required");

        user.Password = newPassword.GetHash();
        await _unitOfWork.User.UpdateAsync(user);
    }
    private string GenerateCode()
    {
        return new Random().Next(9999, 100000).ToString();
    }
}
