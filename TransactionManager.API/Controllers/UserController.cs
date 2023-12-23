using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TransactionManager.API.Commands.Transaction;
using TransactionManager.API.Commands.User;
using TransactionManager.API.Models.User;
using TransactionManager.API.Queries.UserQueries;

namespace TransactionManager.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return result != null ? Ok(result) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var result = await _mediator.Send(new CreateUserCommand(dto));
            return Created($"Created id {result}", null);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto dto, [FromRoute] int id)
        {
            var result = await _mediator.Send(new UpdateUserCommand(dto, id));
            if (!result) return NotFound();
            return Ok();
        }
    }
}
