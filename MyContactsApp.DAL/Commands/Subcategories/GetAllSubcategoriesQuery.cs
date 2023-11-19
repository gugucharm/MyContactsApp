using AutoMapper;
using MediatR;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Subcategories
{
    // Here we define the MediatR's command and it's handler
    // for fetching all Subcategories from the database
    public class GetAllSubcategoriesQuery : IRequest<List<Subcategory>>
    {
    }

    // The handler leverages SubcategoriesRepository class to conduct
    // this operation and returns a list of Subcategories from the database
    public class GetAllSubcategoriesQueryHandler : IRequestHandler<GetAllSubcategoriesQuery, List<Subcategory>>
    {
        private readonly ISubcategoriesRepository _subcategoriesRepository;
        private readonly IMapper _mapper;

        public GetAllSubcategoriesQueryHandler(ISubcategoriesRepository subcategoriesRepository, IMapper mapper)
        {
            _subcategoriesRepository = subcategoriesRepository;
        }

        public async Task<List<Subcategory>> Handle(GetAllSubcategoriesQuery request, CancellationToken cancellationToken)
        {
            var subcategories = await _subcategoriesRepository.GetAllSubcategoriesAsync(cancellationToken);
            return subcategories;
        }
    }
}
