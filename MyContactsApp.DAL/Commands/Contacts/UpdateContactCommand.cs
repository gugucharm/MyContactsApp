using AutoMapper;
using MediatR;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Exceptions;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Contacts
{
    public class UpdateContactCommand : IRequest<Contact>
    {
        public int Id { get; }
        public ContactDTO ContactDto { get; }

        public UpdateContactCommand(int id, ContactDTO contactDto)
        {
            Id = id;
            ContactDto = contactDto;
        }
    }

    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, Contact>
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public UpdateContactHandler(IContactsRepository contactsRepository, ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        public async Task<Contact> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactsRepository.GetContactByIdAsync(request.Id);
            if (contact == null)
            {
                throw new ContactNotFoundException($"Contact with ID {request.Id} not found.");
            }

            var category = await _categoriesRepository.GetCategoryByIdAsync(request.ContactDto.CategoryId, cancellationToken);
            if (category == null)
            {
                throw new CategoryNotFoundException($"Category with Id {request.ContactDto.CategoryId} not found.");
            }

            _mapper.Map(request.ContactDto, contact);
            contact.Category = category;

            return await _contactsRepository.UpdateContactAsync(contact);
        }
    }
}
