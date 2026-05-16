using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.User;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ApiResponse<UserResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<ApiResponse<UserResponseDto>> Handle(DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        var user =   await _userRepository.DeleteUserAsync(request.Id);
        if (user == null) throw new KeyNotFoundException("User you try to delete is not found");
        var userDto = _mapper.Map<UserResponseDto>(user);
        var response = new ApiResponse<UserResponseDto>(userDto,"User successfully deleted");
        return response;
    }
}
