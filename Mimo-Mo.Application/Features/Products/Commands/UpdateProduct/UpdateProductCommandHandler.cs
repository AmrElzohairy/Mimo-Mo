using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Core.Entities;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ApiResponse<ProductResponseDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<ProductResponseDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.ProductDto;

        var product = await _repository.GetProductByIdAsync(dto.Id);

        if (product == null)
            throw new KeyNotFoundException("Product not found");

        if (dto.Name != null)
            product.Name = dto.Name;

        if (dto.Price.HasValue)
            product.Price = dto.Price.Value;

        if (dto.Quantity.HasValue)
            product.Quantity = dto.Quantity.Value;

        await _repository.UpdateProductAsync(dto.Id , product);
        
      var UpdatedProdect = _mapper.Map<ProductResponseDto>(product);

        return  new ApiResponse<ProductResponseDto>(UpdatedProdect);
    }
}