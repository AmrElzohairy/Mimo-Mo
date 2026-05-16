using AutoMapper;
using Mimo_Mo.Application.Dtos.Review;
using Mimo_Mo.Core.Entities;

namespace Mimo_Mo.Application.Mappings;

public class ReviewMappingprofile : Profile
{
    public ReviewMappingprofile()
    {
        CreateMap<CreateReviewDto, Review>();
        CreateMap<UpdateReviewDto, Review>();
        CreateMap<Review, ReviewResponseDto>()
            .ForMember(dest => dest.ReviewedBy, opt => opt.MapFrom(src => src.User.Username));
    }
}