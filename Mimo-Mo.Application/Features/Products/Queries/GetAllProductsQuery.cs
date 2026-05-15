// using AutoMapper;
// using MediatR;
// using Mimo_Mo.Application.Dtos.Product;
// using Mimo_Mo.Core.Interfaces;
//
// namespace Mimo_Mo.Application.Features.Products.Queries;
//
// public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;
//
//
// public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
// {
//     private readonly IProductRepository _productRepository;
//     private readonly IMapper _mapper;
//
//     public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
//     {
//         _productRepository = productRepository;
//         _mapper = mapper;
//     }
//
//     public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
//     {
//         var products = await _productRepository.GetAllProductsAsync();
//
//         var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
//
//         return productDtos;
//     }
// }