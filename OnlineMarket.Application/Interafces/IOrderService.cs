using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Application.Interafces;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int orderId);
    Task<Order?> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersByCategoryAsync(string categoryName);
}
