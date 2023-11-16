using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.Repositories.Interfaces
{
    public interface IContactsRepository
    {
        Task<int> AddContactAsync(Contact contact);
    }
}
