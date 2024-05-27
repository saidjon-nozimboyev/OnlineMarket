using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByCategoryAsync(string categoryName);
    Task<IEnumerable<Order>> GetOrdersByProductAsync(int productId);
}
