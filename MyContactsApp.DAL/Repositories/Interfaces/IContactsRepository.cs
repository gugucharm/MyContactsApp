using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.Repositories.Interfaces
{
    public interface IContactsRepository
    {
        Task<int> AddContactAsync(Contact contact);
        Task<int> UpdateContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(int id);
    }
}
