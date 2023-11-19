using AutoMapper;
using MediatR;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Contacts
{
    public class GetAllContactsQuery : IRequest<List<Contact>>
    {
    }

    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, List<Contact>>
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly IMapper _mapper;

        public GetAllContactsHandler(IContactsRepository contactsRepository, IMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _mapper = mapper;
        }

        public async Task<List<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactsRepository.GetAllContactsAsync(cancellationToken);
            return contacts;
        }
    }
}
