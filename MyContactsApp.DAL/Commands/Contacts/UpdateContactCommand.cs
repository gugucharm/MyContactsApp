using MediatR;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Contacts
{
    public class UpdateContactCommand : IRequest<int>
    {
        public int Id { get; }
        public ContactDTO ContactDto { get; }

        public UpdateContactCommand(int id, ContactDTO contactDto)
        {
            Id = id;
            ContactDto = contactDto;
        }
    }

    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, int>
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public UpdateContactHandler(IContactsRepository contactsRepository, ICategoriesRepository categoriesRepository)
        {
            _contactsRepository = contactsRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<int> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoriesRepository.GetCategoryByNameAsync(request.ContactDto.Category);
            var contact = new Contact
            {
                Id = request.Id,
                FirstName = request.ContactDto.FirstName,
                LastName = request.ContactDto.LastName,
                Email = request.ContactDto.Email,
                CategoryId = category.Id,
                Subcategory = request.ContactDto.Subcategory,
                PhoneNumber = request.ContactDto.PhoneNumber,
                Birthdate = request.ContactDto.Birthdate
            };

            return await _contactsRepository.UpdateContactAsync(contact);
        }
    }

}
