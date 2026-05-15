using MediatR;
using Mimo_Mo.Application.Dtos.Product;

namespace Mimo_Mo.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<IEnumerable<ProductResponseDto>>;
