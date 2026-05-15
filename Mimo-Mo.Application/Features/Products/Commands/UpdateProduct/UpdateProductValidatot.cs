using FluentValidation;

namespace Mimo_Mo.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {

        RuleFor(x => x.ProductDto.Id).NotEmpty().WithMessage("{PropertyName} is required.").GreaterThan(0);
        RuleFor(x => x.ProductDto.Name)
            .NotEmpty()
            .MaximumLength(200)
            .When(x => x.ProductDto.Name != null);

        RuleFor(x => x.ProductDto.Price)
            .GreaterThan(0)
            .When(x => x.ProductDto.Price.HasValue);

        RuleFor(x => x.ProductDto.Quantity)
            .GreaterThanOrEqualTo(0)
            .When(x => x.ProductDto.Quantity.HasValue);
    }
} 
