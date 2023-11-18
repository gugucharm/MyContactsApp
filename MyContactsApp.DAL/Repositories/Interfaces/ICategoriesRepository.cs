using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<Category> GetCategoryByNameAsync(string name);
    }
}
