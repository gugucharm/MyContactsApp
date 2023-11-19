using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.Repositories.Interfaces
{
    // Public interface to work with Contacts table
    public interface IContactsRepository
    {
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> AddContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(int id);
        Task<List<Contact>> GetAllContactsAsync(CancellationToken cancellationToken);
        Task<Contact> GetContactByEmailAsync(string email);
    }
}
