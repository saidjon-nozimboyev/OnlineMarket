using OnlineMarket.Data.DbContexts;
using OnlineMarket.Data.Interfaces;

namespace OnlineMarket.Data.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public ICategoryRepository Category => new CategoryRepository(_dbContext);

    public IProductRepository Product => new ProductRepository(_dbContext);

    public IUserRepository User => new UserRepository(_dbContext);
}
