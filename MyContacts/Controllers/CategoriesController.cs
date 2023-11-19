using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCategoriesApp.DAL.Commands.Categories;
using MyContactsApp.DAL.Queries;

namespace MyContactsApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        // The controller relies on the IMediator interface from MediatR to delegate the processing of requests.
        private readonly IMediator _mediator;

        // The constructor accepts an IMediator instance for dependency injection.
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Method: GetCategoryById
        // Route: GET /[controller]/{id}
        // Description:
        // - This method handles GET requests to retrieve a single category by its ID.
        // - It constructs a GetCategoryByIdQuery with the given ID and sends it via the mediator.
        // - The response from the query (the category's name) is then returned as an HTTP 200 OK.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var categoryName = await _mediator.Send(query);
            return Ok(categoryName);
        }

        // Method: GetAllCategories
        // Route: GET /[controller]
        // Description:
        // - This method deals with GET requests to fetch all categories.
        // - It sends a GetAllCategoriesQuery through the mediator.
        // - The resulting list of categories is returned in an HTTP 200 OK response.
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var categories = await _mediator.Send(query);
            return Ok(categories);
        }
    }
}
