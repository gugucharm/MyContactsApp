using AutoMapper;
using MediatR;
using MyContactsApp.DAL.Commands.Contacts;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Exceptions;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Subcategories
{
    // Here we define the MediatR's command and it's handler
    // for creating a Subcategory
    public class CreateSubcategoryCommand : IRequest<Subcategory>
    {
        public SubcategoryDTO SubcategoryDTO { get; }

        public CreateSubcategoryCommand(SubcategoryDTO subcategoryDTO)
        {
            SubcategoryDTO = subcategoryDTO;
        }
    }

    // The handler leverages ContactsRepository class to conduct
    // this operation with the help of a mapper to convert
    // SubcategoryDTO to Subcategory model
    public class CreateSubcategoryHandler : IRequestHandler<CreateSubcategoryCommand, Subcategory>
    {
        private readonly ISubcategoriesRepository _subcategoriesRepository;
        private readonly IMapper _mapper;

        public CreateSubcategoryHandler(ISubcategoriesRepository subcategoriesRepository, IMapper mapper)
        {
            _subcategoriesRepository = subcategoriesRepository;
            _mapper = mapper;
        }

        public async Task<Subcategory> Handle(CreateSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var subcategory = _mapper.Map<Subcategory>(request.SubcategoryDTO);
            return await _subcategoriesRepository.AddSubcategoryAsync(subcategory);
        }
    }
}
