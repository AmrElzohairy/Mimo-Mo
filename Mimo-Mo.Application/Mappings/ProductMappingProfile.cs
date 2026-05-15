using AutoMapper;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Core.Entities;

namespace Mimo_Mo.Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // Mapping from Entity to Response DTO
        CreateMap<Product, ProductResponseDto>();
        
        // Mapping from Create DTO to Entity
        CreateMap<CreateProductDto, Product>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
    }
}