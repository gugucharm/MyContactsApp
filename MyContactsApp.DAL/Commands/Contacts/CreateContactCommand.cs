using MediatR;
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
        private readonly IContactsRepository _repository;

        public CreateContactHandler(IContactsRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                FirstName = request.ContactDto.FirstName,
                LastName = request.ContactDto.LastName,
                Email = request.ContactDto.Email,
                CategoryId = request.ContactDto.CategoryId,
                Subcategory = request.ContactDto.Subcategory,
                PhoneNumber = request.ContactDto.PhoneNumber,
                Birthdate = request.ContactDto.Birthdate
            };

            return await _repository.AddContactAsync(contact);
        }
    }
}
