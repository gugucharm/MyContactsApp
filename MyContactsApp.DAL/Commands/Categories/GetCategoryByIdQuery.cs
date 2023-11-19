using MediatR;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Queries
{
    // Here we define the MediatR's query and it's handler
    // for a Category by it's id
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public int CategoryId { get; }

        public GetCategoryByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }

    // The handler leverages CategoriesRepository class to conduct
    // a query on the Categories table and return the object with
    // the corresponding id
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public GetCategoryByIdHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoriesRepository.GetCategoryByIdAsync(request.CategoryId, cancellationToken);
            return category;
        }
    }
}
