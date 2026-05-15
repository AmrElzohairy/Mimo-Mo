using FluentValidation;

namespace Mimo_Mo.Application.Features.Products.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.ProductDto.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.ProductDto.Price).GreaterThan(0);
        RuleFor(x => x.ProductDto.Quantity).GreaterThanOrEqualTo(0);
    }
}