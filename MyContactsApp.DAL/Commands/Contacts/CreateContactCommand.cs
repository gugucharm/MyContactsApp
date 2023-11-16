﻿using MediatR;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Contacts
{
    public class CreateContactCommand : IRequest<int>
    {
        public ContactDTO ContactDto { get; }

        public CreateContactCommand(ContactDTO contactDto)
        {
            ContactDto = contactDto;
        }
    }

    public class CreateContactHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public CreateContactHandler(IContactsRepository contactsRepository, ICategoriesRepository categoriesRepository)
        {
            _contactsRepository = contactsRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoriesRepository.GetCategoryByNameAsync(request.ContactDto.Category);
            var contact = new Contact
            {
                FirstName = request.ContactDto.FirstName,
                LastName = request.ContactDto.LastName,
                Email = request.ContactDto.Email,
                CategoryId = category.Id,
                Subcategory = request.ContactDto.Subcategory,
                PhoneNumber = request.ContactDto.PhoneNumber,
                Birthdate = request.ContactDto.Birthdate
            };

            return await _contactsRepository.AddContactAsync(contact);
        }
    }
}
