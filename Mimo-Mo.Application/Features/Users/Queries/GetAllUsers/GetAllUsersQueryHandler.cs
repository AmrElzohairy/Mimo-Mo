using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.User;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery,ApiResponse<IEnumerable<UserResponseDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<ApiResponse<IEnumerable<UserResponseDto>>> Handle(GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUsersAsync();

        var userDtos = _mapper.Map<IEnumerable<UserResponseDto>>(users);

        var response = new ApiResponse<IEnumerable<UserResponseDto>>(userDtos);
        return response;
    }
}