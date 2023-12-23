using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransactionManager.API.Commands.Category;
using TransactionManager.API.Configs;
using TransactionManager.API.Models.Category;
using TransactionManager.API.Queries.CategoryQueries;

namespace TransactionManager.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public CategoryController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediatR.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var result = await _mediatR.Send(new GetCategoryByIdQuery(id));
            return result != null ? Ok(result) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            var result = await _mediatR.Send(new CreateCategoryCommand(dto));
            return Created($"Created id {result}", null);
        }
    }
}
