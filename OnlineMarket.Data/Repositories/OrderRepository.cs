using Microsoft.EntityFrameworkCore;
using OnlineMarket.Data.DbContexts;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.Repositories;

public class OrderRepository(AppDbContext dbContext) : GenericRepository<Order>(dbContext), IOrderRepository
{
    public async Task<IEnumerable<Order>> GetOrdersByCategoryAsync(string categoryName)
    {
        return await _dbContext.Orders
                               .Include(o => o.Category)
                               .Include(o => o.Product)
                               .Where(o => o.Category.CategoryName == categoryName)
                               .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByProductAsync(int productId)
    {
        return await _dbContext.Orders
                               .Include(o => o.Category)
                               .Include(o => o.Product)
                               .Where(o => o.Product.Id == productId)
                               .ToListAsync();
    }
}