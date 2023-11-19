using AutoMapper;
using MediatR;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Subcategories
{
    public class GetAllSubcategoriesQuery : IRequest<List<Subcategory>>
    {
    }

    public class GetAllSubcategoriesQueryHandler : IRequestHandler<GetAllSubcategoriesQuery, List<Subcategory>>
    {
        private readonly ISubcategoriesRepository _subcategoriesRepository;
        private readonly IMapper _mapper;

        public GetAllSubcategoriesQueryHandler(ISubcategoriesRepository subcategoriesRepository, IMapper mapper)
        {
            _subcategoriesRepository = subcategoriesRepository;
            _mapper = mapper;
        }

        public async Task<List<Subcategory>> Handle(GetAllSubcategoriesQuery request, CancellationToken cancellationToken)
        {
            var subcategories = await _subcategoriesRepository.GetAllSubcategoriesAsync(cancellationToken);
            return subcategories;
        }
    }
}
