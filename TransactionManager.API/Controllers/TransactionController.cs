using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransactionManager.API.Models.Transaction;

namespace TransactionManager.API.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllByUserId([FromRoute] int userId)
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto dto)
        {
            return Ok();
        }
    }
}
