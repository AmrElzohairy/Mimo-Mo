using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mimo_Mo.Application.Dtos.Auth;
using Mimo_Mo.Application.Features.Users.Commands.Login;
using Mimo_Mo.Application.Features.Users.Commands.Register;
using Mimo_Mo.Application.Features.Users.Queries.GetUserById;
using Mimo_Mo.Application.Features.Users.Queries.GetAllUsers;

namespace Mimi_Mo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;   
        
        public UsersController(IMediator mediator) => _mediator = mediator;
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _mediator.Send(new UserRegisterCommand(registerDto));
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(Id));
            return Ok(result);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto loginDtoDto)
        {
            var result = await _mediator.Send(new UserLoginCommand(loginDtoDto));
            return Ok(result);
        }
    }
}
