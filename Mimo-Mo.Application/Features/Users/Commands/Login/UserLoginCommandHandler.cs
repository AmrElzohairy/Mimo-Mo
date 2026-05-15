using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.Auth;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Users.Commands.Login;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ApiResponse<AuthResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    public UserLoginCommandHandler(IUserRepository userRepository, IJwtService jwtService, IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    public async Task<ApiResponse<AuthResponseDto>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsernameAsync(request.loginDto.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.loginDto.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");

        var token = _jwtService.GenerateToken(user);
        var response = _mapper.Map<AuthResponseDto>(user);
        response.Token = token;

        return new ApiResponse<AuthResponseDto>(response, "Login successful");
    }
}