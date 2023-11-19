using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.DatabaseContext;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Repositories
{
    // Public Contacts repository implementing interface's methods
    public class ContactsRepository : IContactsRepository
    {
        private readonly MyContext _context;

        // Constructor with DbContext dependency injection
        public ContactsRepository(MyContext context)
        {
            _context = context;
        }

        // Returning a Contact based on a corresponding id
        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        // Adding a Contact to the table
        public async Task<Contact> AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        // Updating a Contact in the database
        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        // Deleting a Contact based on the corresponding id,
        // returns whether it was successful or not
        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false;
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        // Fetching a list of all the Contacts from the table
        public async Task<List<Contact>> GetAllContactsAsync(CancellationToken cancellationToken)
        {
            return await _context.Contacts
                                 .Include(c => c.Category)
                                 .ToListAsync(cancellationToken);
        }

        // Fetching a Contact based on it's email from the table
        public async Task<Contact> GetContactByEmailAsync(string email)
        {
            var contact = await _context.Contacts
                                        .Where(c => c.Email == email)
                                        .FirstOrDefaultAsync();

            return contact;
        }
    }
}
