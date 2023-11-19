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
        // The controller uses the IMediator interface from MediatR to handle commands and queries.
        private readonly IMediator _mediator;

        // Constructor for dependency injection of the IMediator instance.
        public SubcategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Method: CreateSubcategory
        // Route: POST /[controller]
        // Description:
        // - Manages the creation of a new subcategory using the provided SubcategoryDTO.
        // - Sends a CreateSubcategoryCommand to the mediator and returns the created subcategory details.
        [HttpPost]
        public async Task<IActionResult> CreateSubcategory([FromBody] SubcategoryDTO subcategoryDTO)
        {
            var command = new CreateSubcategoryCommand(subcategoryDTO);
            var subcategory = await _mediator.Send(command);
            return Ok(subcategory);
        }

        // Method: GetAllSubcategories
        // Route: GET /[controller]
        // Description:
        // - Retrieves all subcategories.
        // - Sends a GetAllSubcategoriesQuery to the mediator and returns the list of subcategories.
        [HttpGet]
        public async Task<IActionResult> GetAllSubcategories()
        {
            var query = new GetAllSubcategoriesQuery();
            var subcategories = await _mediator.Send(query);
            return Ok(subcategories);
        }
    }
}
