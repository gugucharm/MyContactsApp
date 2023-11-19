using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyContactsApp.DAL.Commands.Subcategories;
using MyContactsApp.DAL.DTOs;

namespace MySubcategoriesApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubcategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubcategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubcategory([FromBody] SubcategoryDTO subcategoryDTO)
        {
            var command = new CreateSubcategoryCommand(subcategoryDTO);
            var subcategory = await _mediator.Send(command);
            return Ok(subcategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubcategories()
        {
            var query = new GetAllSubcategoriesQuery();
            var subcategories = await _mediator.Send(query);
            return Ok(subcategories);
        }
    }
}
