using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.DatabaseContext;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Repositories
{
    // Public Users repository implementing interface's methods
    public class UsersRepository : IUsersRepository
    {
        private readonly MyContext _context;

        // Constructor with DbContext dependency injection
        public UsersRepository(MyContext context)
        {
            _context = context;
        }

        // Adding a User to the Users table
        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Fetching a User based on it's unique email
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
