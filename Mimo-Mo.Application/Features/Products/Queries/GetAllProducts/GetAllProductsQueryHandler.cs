using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler 
    : IRequestHandler<GetAllProductsQuery, ApiResponse<IEnumerable<ProductResponseDto>>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(
        IProductRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<ProductResponseDto>>> Handle(
        GetAllProductsQuery request, 
        CancellationToken cancellationToken)
    {
        // 1. Get the raw entities from the repo
        var products = await _repository.GetAllProductsAsync();

        // 2. Map the entities to the DTO list
        var productDtos = _mapper.Map<IEnumerable<ProductResponseDto>>(products);

        // 3. Wrap the DTOs in your ApiResponse manually
        return new ApiResponse<IEnumerable<ProductResponseDto>>(productDtos, "Products retrieved successfully");
    }
}