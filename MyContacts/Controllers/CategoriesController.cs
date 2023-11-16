using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyContactsApp.DAL.Commands.Categories;
using MyContactsApp.DAL.Models;

namespace MyContactsApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Category>> GetCategoryByName(string name)
        {
            var category = await _mediator.Send(new GetCategoryByNameQuery(name));
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
