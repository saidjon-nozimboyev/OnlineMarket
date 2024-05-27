namespace OnlineMarket.Domain.Entities;

public class Order : Base
{
    public Category Category { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
