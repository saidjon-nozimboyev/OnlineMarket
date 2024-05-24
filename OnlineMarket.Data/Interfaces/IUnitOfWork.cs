namespace OnlineMarket.Data.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IProductRepository Product { get; }
    IUserRepository User { get; }
}
