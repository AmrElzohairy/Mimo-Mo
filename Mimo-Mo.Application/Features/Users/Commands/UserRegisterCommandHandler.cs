using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.User;
using Mimo_Mo.Core.Entities;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Users.Commands;

public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand,ApiResponse<UserResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserRegisterCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<UserResponseDto>> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.registerDto);
        await _userRepository.CreateUserAsync(user);
        return new ApiResponse<UserResponseDto>(_mapper.Map<UserResponseDto>(user),"User Registered Successfully");
    }
}