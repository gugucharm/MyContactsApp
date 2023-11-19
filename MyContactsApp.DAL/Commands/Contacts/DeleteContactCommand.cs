using MediatR;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Contacts
{
    // Here we define the MediatR's command and it's handler
    // for deleting a Contact from the database
    public class DeleteContactCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteContactCommand(int id)
        {
            Id = id;
        }
    }

    // The handler leverages ContactsRepository class to delete
    // the contact only using it's id
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, bool>
    {
        private readonly IContactsRepository _contactsRepository;

        public DeleteContactHandler(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            return await _contactsRepository.DeleteContactAsync(request.Id);
        }
    }
}
