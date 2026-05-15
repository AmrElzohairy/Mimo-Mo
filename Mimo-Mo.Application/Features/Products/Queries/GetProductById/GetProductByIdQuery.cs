using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.Product;

namespace Mimo_Mo.Application.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<ApiResponse<ProductResponseDto>>;
