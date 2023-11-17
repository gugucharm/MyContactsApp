using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyContactsApp.DAL.Commands.Subcategories;
using MyContactsApp.DAL.DTOs;

namespace MySubcategoriesApp.API.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> CreateContact([FromBody] SubcategoryDTO subcategoryDTO)
        {
            var command = new CreateSubcategoryCommand(subcategoryDTO);
            var subcategory = await _mediator.Send(command);
            return Ok(subcategory);
        }
    }
}
