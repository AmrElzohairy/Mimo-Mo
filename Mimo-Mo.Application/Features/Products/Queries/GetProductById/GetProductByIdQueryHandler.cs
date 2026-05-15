using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery,ApiResponse<ProductResponseDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<ProductResponseDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByIdAsync(request.Id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {request.Id} was not found.");
        }
        var productDto = _mapper.Map<ProductResponseDto>(product);
        return new ApiResponse<ProductResponseDto>(productDto);
    }
}