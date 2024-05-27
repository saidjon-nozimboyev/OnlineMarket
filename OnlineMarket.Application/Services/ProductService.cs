using FluentValidation;
using OnlineMarket.Application.DTOs.ProductDTOs;
using OnlineMarket.Application.Interafces;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Application.Services;

public class ProductService(IUnitOfWork unitOfWork,
                            IValidator<Product> validator) 
    : IProductService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<Product> validator = validator;

    public Task CreateAsync(AddProductDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByPriceAsync(double price)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ProductDto dto)
    {
        throw new NotImplementedException();
    }
}
