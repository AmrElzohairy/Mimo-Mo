using MediatR;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Application.Features.Common.Responses;

namespace Mimo_Mo.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(CreateProductDto ProductDto) : IRequest<ApiResponse<ProductResponseDto>>;