using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
