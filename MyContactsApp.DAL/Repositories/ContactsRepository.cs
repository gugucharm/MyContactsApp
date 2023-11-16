using MyContactsApp.DAL.DatabaseContext;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly MyContext _context;

        public ContactsRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<int> AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact.Id;
        }
    }
}
