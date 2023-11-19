using AutoMapper;
using MediatR;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Contacts
{
    // Here we define the MediatR's command and it's handler
    // for fetching all Contaats from the database
    public class GetAllContactsQuery : IRequest<List<Contact>>
    {
    }

    // The handler leverages ContactsRepository class to conduct
    // the operation
    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, List<Contact>>
    {
        private readonly IContactsRepository _contactsRepository;

        public GetAllContactsHandler(IContactsRepository contactsRepository, IMapper mapper)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task<List<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactsRepository.GetAllContactsAsync(cancellationToken);
            return contacts;
        }
    }
}
