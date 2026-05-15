using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.Auth;
using Mimo_Mo.Application.Dtos.User;

namespace Mimo_Mo.Application.Features.Users.Commands;

public record UserRegisterCommand(RegisterDto registerDto) : IRequest<ApiResponse<UserResponseDto>>;
