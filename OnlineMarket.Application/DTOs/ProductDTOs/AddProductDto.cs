using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Application.DTOs.ProductDTOs;

public class AddProductDto
{
    public int CategoryId { get; set; } 
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public double ProductPrice { get; set; }
    public int ProductPiece { get; set; }
    public double ProductRating { get; set; } = 5;

    public Category Category = null!;

    public static implicit operator Product(AddProductDto dto)
    {
        return new Product()
        {
            CategoryId = dto.CategoryId,
            Category = dto.Category,
            ProductName = dto.ProductName,
            ProductDescription = dto.ProductDescription,
            ProductPrice = dto.ProductPrice,
            ProductPiece = dto.ProductPiece,
            ProductRating = dto.ProductRating
        };
    }
}
