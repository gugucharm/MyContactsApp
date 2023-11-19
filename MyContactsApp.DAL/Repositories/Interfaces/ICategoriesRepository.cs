using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<Category> GetCategoryByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);
    }
}
