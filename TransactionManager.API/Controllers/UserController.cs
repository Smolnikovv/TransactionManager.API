using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TransactionManager.API.Models.User;

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
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto dto, [FromRoute] int id)
        {
            return Ok();
        }
    }
}
