using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.User;

namespace Mimo_Mo.Application.Features.Users.Queries.GetAllUsers;

public record GetAllUsersQuery : IRequest<ApiResponse<IEnumerable<UserResponseDto>>>;
