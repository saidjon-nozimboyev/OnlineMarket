using OnlineMarket.Application.DTOs.UserDTOs;

namespace OnlineMarket.Application.Interafces;

public interface IAccountService
{
    Task<bool> RegisterAsync(AddUserDto dto);
    Task<string> LoginAsync(LoginDto login);
    Task SendCodeAsync(string email);
    Task CheckCodeAsync(string email, string code);
    Task UpdatePasswordAsync(string email, string newPassword);
}
