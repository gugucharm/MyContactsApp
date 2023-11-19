using MediatR;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Contacts
{
    // Here we define the MediatR's command and it's handler
    // for fetching a contact by it's email
    public class GetContactByEmailQuery : IRequest<Contact>
    {
        public string Email { get; }

        public GetContactByEmailQuery(string email)
        {
            Email = email;
        }
    }

    // The handler leverages ContactsRepository class to conduct
    // this operation by email, because it's unique for every Contact
    public class GetContactByEmailQueryHandler : IRequestHandler<GetContactByEmailQuery, Contact>
    {
        private readonly IContactsRepository _contactsRepository;

        public GetContactByEmailQueryHandler(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task<Contact> Handle(GetContactByEmailQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactsRepository.GetContactByEmailAsync(request.Email);
            return contact;
        }
    }
}
