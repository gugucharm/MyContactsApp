using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.Repositories.Interfaces
{
    // Public interface to work with Subcategories table
    public interface ISubcategoriesRepository
    {
        Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory);
        Task<List<Subcategory>> GetAllSubcategoriesAsync(CancellationToken cancellationToken);
    }
}
