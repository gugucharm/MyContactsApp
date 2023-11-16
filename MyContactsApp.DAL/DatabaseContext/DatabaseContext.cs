using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.DatabaseContext
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    }
}
