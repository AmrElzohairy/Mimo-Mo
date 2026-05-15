using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResponse<ProductResponseDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<ProductResponseDto>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product =  await _productRepository.DeleteProductAsync(request.Id);
        if (product == null) throw new KeyNotFoundException("Product you try to delete is not exist");
        var productDto = _mapper.Map<ProductResponseDto>(product);
        var response = new ApiResponse<ProductResponseDto>(productDto);
        return   response;
    }
}