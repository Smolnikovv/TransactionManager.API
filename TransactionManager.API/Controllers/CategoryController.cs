using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransactionManager.API.Models.Category;

namespace TransactionManager.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public CategoryController(IMediator mediator) 
        {
            _mediatR = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            return Ok();
        }
    }
}
