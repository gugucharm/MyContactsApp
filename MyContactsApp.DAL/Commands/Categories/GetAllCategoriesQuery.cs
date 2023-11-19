using AutoMapper;
using MediatR;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyCategoriesApp.DAL.Commands.Categories
{
    // Here we define the MediatR's query and it's handler
    // for fetching all categories
    public class GetAllCategoriesQuery : IRequest<List<Category>>
    {
    }

    // The handler leverages CategoriesRepository class to conduct
    // a query on the Categories table and return a list of them
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public GetAllCategoriesHandler(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoriesRepository.GetAllCategoriesAsync(cancellationToken);
            return categories;
        }
    }
}
