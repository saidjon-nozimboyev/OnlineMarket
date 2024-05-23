namespace OnlineMarket.Domain.Entities;

public class Product : Base
{
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public double ProductPrice { get; set; } 
    public int ProductPiece { get; set; }
    public double ProductRating { get; set; } = 5; 
    public int CategoryId { get; set; } 
}