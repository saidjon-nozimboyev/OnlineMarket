using OnlineMarket.Application.DTOs.ProductDTOs;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Application.Interafces;

public interface IProductService
{
    Task<Product> GetByPriceAsync(double price);
    Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName);
    Task CreateAsync(AddProductDto dto);
    Task UpdateAsync(ProductDto dto);
    Task DeleteAsync(int id);
    Task<ProductDto?> GetByIdAsync(int id);
    Task<IEnumerable<ProductDto>> GetAllAsync();
}
