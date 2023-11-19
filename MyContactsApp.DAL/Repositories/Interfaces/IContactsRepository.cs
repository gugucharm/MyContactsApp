using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.Repositories.Interfaces
{
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
