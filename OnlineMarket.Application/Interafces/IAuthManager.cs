using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Application.Interafces;

public interface IAuthManager
{
    string GenerateToken(User user);
}
