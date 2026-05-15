using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.Product;

namespace Mimo_Mo.Application.Features.Products.Commands.UpdateProduct;

public record UpdateProductCommand(UpdateProductDto  ProductDto) : IRequest<ApiResponse<ProductResponseDto>>;
