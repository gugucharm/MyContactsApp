using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.DatabaseContext;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Repositories
{
    // Public Subcategories repository implementing interface's methods
    public class SubcategoriesRepository : ISubcategoriesRepository
    {
        private readonly MyContext _context;

        // Constructor with DbContext dependency injection
        public SubcategoriesRepository(MyContext context)
        {
            _context = context;
        }

        // Adding a Subcategory to the table
        public async Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }

        // Returning a list of all Subcategories from the table
        public async Task<List<Subcategory>> GetAllSubcategoriesAsync(CancellationToken cancellationToken)
        {
            return await _context.Subcategories.ToListAsync(cancellationToken);
        }
    }
}
