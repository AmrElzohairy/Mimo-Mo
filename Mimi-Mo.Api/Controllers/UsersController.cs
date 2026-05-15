using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mimo_Mo.Application.Dtos.Auth;
using Mimo_Mo.Application.Features.Users.Commands;

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
    }
}
