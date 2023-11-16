using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<int> AddUserAsync(User user);
    }
}
