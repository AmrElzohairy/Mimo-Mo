using AutoMapper;
using Mimo_Mo.Application.Dtos.Auth;
using Mimo_Mo.Application.Dtos.User;
using Mimo_Mo.Core.Entities;

namespace Mimo_Mo.Application.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserResponseDto>();
        CreateMap<User, AuthResponseDto>();
      
        CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

    }
}