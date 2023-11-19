using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.Repositories.Interfaces
{
    // Public interface to work with Categories table
    public interface ICategoriesRepository
    {
        Task<Category> GetCategoryByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);
    }
}
