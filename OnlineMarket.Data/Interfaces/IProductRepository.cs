using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetByPriceAsync(double price);
    Task<IEnumerable<Product>> GetByNameAsync(string productName);  
    Task<IEnumerable<Product>> GetProductByCategoryAsync(string categoryName);
}