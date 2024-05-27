using OnlineMarket.Domain.Entities;
using OnlineMarket.Domain.Enums;

namespace OnlineMarket.Application.DTOs.UserDTOs;

public class UpdateUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }

    public static implicit operator User(UpdateUserDto user)
    {
        return new User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Gender = user.Gender,
            PhoneNumber = user.PhoneNumber,
        };
    }
}
