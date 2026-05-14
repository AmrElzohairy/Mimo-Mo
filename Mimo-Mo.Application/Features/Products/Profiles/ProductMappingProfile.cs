using AutoMapper;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Application.Features.Products.Commands;
using Mimo_Mo.Core.Entities;

namespace Mimo_Mo.Application.Features.Products.Profiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<CreateProductCommand, Product>();
        
        CreateMap<UpdateProductCommand, Product>();
        
        CreateMap<Product, ProductDto>();
    }
}