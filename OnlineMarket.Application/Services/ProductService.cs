using FluentValidation;
using OnlineMarket.Application.Common.Exceptions;
using OnlineMarket.Application.Common.Validators;
using OnlineMarket.Application.DTOs.ProductDTOs;
using OnlineMarket.Application.Interafces;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;
using System.Net;

namespace OnlineMarket.Application.Services;

public class ProductService(IUnitOfWork unitOfWork,
                            IValidator<Product> validator) 
    : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Product> _validator = validator;

    public async Task CreateAsync(AddProductDto dto)
    {
        if (dto is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Dto can not be null");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        await _unitOfWork.Product.CreateAsync(dto);
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _unitOfWork.Product.GetByIdAsync(id);
        if (product is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Product with this id not found");

        await _unitOfWork.Product.DeleteAsync(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _unitOfWork.Product.GetAllAsync(x => x.ProductPrice > 0);
        return products.Select(x => (ProductDto)x);
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName)
    {
        var products = await _unitOfWork.Product.GetAllAsync(x => x.ProductPrice > 0 && x.Category.CategoryName == categoryName);

        return (IEnumerable<Product>)products.Select(x => new ProductDto
        {
            Id = x.Id,
            ProductName = x.ProductName,
            ProductDescription = x.ProductDescription, // Map other properties
            ProductPrice = x.ProductPrice,
            ProductPiece = x.ProductPiece,
            ProductRating = x.ProductRating,
        }).ToList();
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Product.GetByIdAsync(id);
        return product != null ? (ProductDto)product : null;
    }

    public async Task<Product> GetByPriceAsync(double price)
    {
        if (price < 0)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Price can not be 0");
        var product = await _unitOfWork.Product.GetByPriceAsync(price);
        return product!;
    }

    public async Task UpdateAsync(ProductDto dto)
    {
        if (dto is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Dto cannot be null");

        var existingProduct = await _unitOfWork.Product.GetByIdAsync(dto.Id);
        if (existingProduct is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Product not found");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        await _unitOfWork.Product.UpdateAsync(existingProduct);
    }
}
