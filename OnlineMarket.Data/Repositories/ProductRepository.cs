using Microsoft.EntityFrameworkCore;
using OnlineMarket.Data.DbContexts;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.Repositories;

public class ProductRepository(AppDbContext dbContext) 
    : GenericRepository<Product>(dbContext), IProductRepository
{
    public async Task<IEnumerable<Product>> GetByNameAsync(string productName)
    {
        return await _dbContext.Products
                               .Where(p => p.ProductName.Contains(productName))
                               .ToListAsync();
    }

    public async Task<Product?> GetByPriceAsync(double price)
    {
        return await _dbContext.Products
                               .FirstOrDefaultAsync(p => p.ProductPrice == price);
    }

    public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string categoryName)
    {
        return await _dbContext.Products
                           .Where(p => p.Category.CategoryName == categoryName)
                           .ToListAsync();
    }
}