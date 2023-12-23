using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransactionManager.API.Commands.Transaction;
using TransactionManager.API.Entities;
using TransactionManager.API.Models.Transaction;
using TransactionManager.API.Queries.TransactionQueries;

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
            var result = await _mediator.Send(new GetAllUserTransactionsQuery(userId));
            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetTransacationByIdQuery(id));
            return result != null ? Ok(result) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto dto)
        {
            var result = await _mediator.Send(new CreateTransactionCommand(dto));
            return Created($"Created id {result}", null);
        }
    }
}
