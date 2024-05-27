using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Application.DTOs.ProductDTOs;

public class ProductDto : AddProductDto
{
    public int Id { get; set; }

    public static implicit operator ProductDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            Category = product.Category,
            ProductPiece = product.ProductPiece,
            ProductPrice = product.ProductPrice,
            ProductRating = product.ProductRating,
        };
    }

    public static implicit operator Product(ProductDto product)
    {
        return new Product()
        {
            Id = product.Id,
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            Category = product.Category,
            ProductPiece = product.ProductPiece,
            ProductPrice = product.ProductPrice,
            ProductRating = product.ProductRating,
        };
    }
}
