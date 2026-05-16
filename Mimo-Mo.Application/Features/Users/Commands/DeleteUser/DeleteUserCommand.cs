using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.User;

namespace Mimo_Mo.Application.Features.Users.Commands.DeleteUser;

public record DeleteUserCommand(int Id) : IRequest<ApiResponse<UserResponseDto>>; 
