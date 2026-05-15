using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Core.Entities;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ApiResponse<ProductResponseDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public CreateProductHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<ProductResponseDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Product>(request.ProductDto);
        var result = await _repository.CreateProductAsync(entity);
        var responseDto = _mapper.Map<ProductResponseDto>(result);
        return new ApiResponse<ProductResponseDto>(responseDto, "Product created successfully");
    }
}