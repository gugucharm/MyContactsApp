using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.DatabaseContext;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly MyContext _context;

        public CategoriesRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await _context.Categories
                                 .FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
