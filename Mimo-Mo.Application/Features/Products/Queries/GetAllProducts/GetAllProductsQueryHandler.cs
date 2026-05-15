using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler 
    : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponseDto>>
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

    public async Task<IEnumerable<ProductResponseDto>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllProductsAsync();

        var result = _mapper.Map<IEnumerable<ProductResponseDto>>(products);

        return result;
    }
}