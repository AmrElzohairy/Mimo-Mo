using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.User;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,ApiResponse<UserResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<UserResponseDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);
        if (user == null) throw new KeyNotFoundException("User Not Found");
        var userDto =  _mapper.Map<UserResponseDto>(user);
        return new ApiResponse<UserResponseDto>(userDto);
    }
}