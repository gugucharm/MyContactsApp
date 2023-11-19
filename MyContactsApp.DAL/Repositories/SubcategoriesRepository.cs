using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.DatabaseContext;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Repositories
{
    public class SubcategoriesRepository : ISubcategoriesRepository
    {
        private readonly MyContext _context;

        public SubcategoriesRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }

        public async Task<List<Subcategory>> GetAllSubcategoriesAsync(CancellationToken cancellationToken)
        {
            return await _context.Subcategories.ToListAsync(cancellationToken);
        }
    }
}
