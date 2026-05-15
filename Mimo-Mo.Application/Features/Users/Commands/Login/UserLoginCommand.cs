using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.Auth;

namespace Mimo_Mo.Application.Features.Users.Commands.Login;

public record UserLoginCommand(LoginDto loginDto) : IRequest<ApiResponse<AuthResponseDto>>;
