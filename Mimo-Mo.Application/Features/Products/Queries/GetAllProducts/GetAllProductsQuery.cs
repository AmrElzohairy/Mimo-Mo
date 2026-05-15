using MediatR;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Application.Common.Responses;

namespace Mimo_Mo.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<ApiResponse<IEnumerable<ProductResponseDto>>>;
