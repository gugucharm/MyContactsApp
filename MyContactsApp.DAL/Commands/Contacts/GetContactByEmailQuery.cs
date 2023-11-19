using MediatR;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Contacts
{
    public class GetContactByEmailQuery : IRequest<Contact>
    {
        public string Email { get; }

        public GetContactByEmailQuery(string email)
        {
            Email = email;
        }
    }

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
