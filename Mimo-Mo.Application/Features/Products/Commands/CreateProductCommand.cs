using AutoMapper;
using FluentValidation;
using MediatR;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Core.Entities;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Products.Commands;

public record CreateProductCommand : IRequest<ProductDto>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    
    public string? Image { get; set; }
    public int Quantity { get; set; }
}

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(255);
        RuleFor(p => p.Description).NotEmpty().MaximumLength(500);
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Quantity).GreaterThanOrEqualTo(0);
        RuleFor(p => p.DiscountPrice).LessThan(p => p.Price).When(p => p.DiscountPrice.HasValue);
    }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = _mapper.Map<Product>(request);

        var createdProduct = await _productRepository.CreateProductAsync(productEntity);

        return _mapper.Map<ProductDto>(createdProduct);
    }
}