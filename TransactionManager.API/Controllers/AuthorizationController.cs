using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransactionManager.API.Commands.Authorization;
using TransactionManager.API.Models.User;

namespace TransactionManager.API.Controllers
{
    [Route("api/authorization")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto dto)
        {
            var result = await _mediator.Send(new RegisterCommand(dto)); 
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _mediator.Send(new LoginCommand(dto));
            return Ok(result);
        }
    }
}
