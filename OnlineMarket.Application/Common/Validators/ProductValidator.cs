using FluentValidation;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Application.Common.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty()
            .WithMessage("Product name is required")
            .MinimumLength(3)
            .WithMessage("Product name must be at least 3 characters long")
            .MaximumLength(100)
            .WithMessage("Product name cannot exceed 100 characters");

        RuleFor(p => p.ProductDescription)
            .NotEmpty()
            .WithMessage("Product description is required")
            .MinimumLength(10)
            .WithMessage("Product description must be at least 10 characters long")
            .MaximumLength(1000)
            .WithMessage("Product description cannot exceed 1000 characters");

        RuleFor(p => p.ProductPrice)
            .NotEmpty()
            .WithMessage("Product price is required")
            .GreaterThan(0)
            .WithMessage("Product price must be greater than 0");

        RuleFor(p => p.ProductPiece)
            .NotEmpty()
            .WithMessage("Product piece quantity is required")
            .GreaterThanOrEqualTo(0)
            .WithMessage("Product piece quantity must be 0 or greater");
    }
}
