using AutoMapper;
using MediatR;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyCategoriesApp.DAL.Commands.Categories
{
    public class GetAllCategoriesQuery : IRequest<List<Category>>
    {
    }

    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoriesRepository.GetAllCategoriesAsync(cancellationToken);
            return categories;
        }
    }
}
