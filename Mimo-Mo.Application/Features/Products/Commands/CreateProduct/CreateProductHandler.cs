using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Core.Entities;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public CreateProductHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Product>(request.ProductDto);
        var result = await _repository.CreateProductAsync(entity);
        return _mapper.Map<ProductResponseDto>(result);
    }
}