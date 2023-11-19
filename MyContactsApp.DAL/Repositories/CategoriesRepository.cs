using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.DatabaseContext;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Repositories
{
    // Public Categories repository implementing interface's methods
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly MyContext _context;

        // Constructor with DbContext dependency injection
        public CategoriesRepository(MyContext context)
        {
            _context = context;
        }

        // Returning a Category based on a corresponding id
        public async Task<Category> GetCategoryByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        // Returning a list of all Categories from the table
        public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return await _context.Categories.ToListAsync(cancellationToken);
        }
    }
}
