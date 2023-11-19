using AutoMapper;
using MediatR;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Exceptions;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Contacts
{
    public class CreateContactCommand : IRequest<Contact>
    {
        public ContactDTO ContactDto { get; }

        public CreateContactCommand(ContactDTO contactDto)
        {
            ContactDto = contactDto;
        }
    }

    public class CreateContactHandler : IRequestHandler<CreateContactCommand, Contact>
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public CreateContactHandler(IContactsRepository contactsRepository, ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        public async Task<Contact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoriesRepository.GetCategoryByIdAsync(request.ContactDto.CategoryId, cancellationToken);
            if (category == null)
            {
                throw new CategoryNotFoundException($"Category with Id {request.ContactDto.CategoryId} not found.");
            }

            var contact = _mapper.Map<Contact>(request.ContactDto);

            contact.CategoryId = category.Id;
            contact.Category = category;

            return await _contactsRepository.AddContactAsync(contact);
        }
    }
}
