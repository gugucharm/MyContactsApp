using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.Repositories.Interfaces
{
    public interface ISubcategoriesRepository
    {
        Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory);
        Task<List<Subcategory>> GetAllSubcategoriesAsync(CancellationToken cancellationToken);
    }
}
