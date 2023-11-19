using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.DatabaseContext
{
    // We're defining our database context for the use the EF Core
    public class MyContext : DbContext
    {
        // We're declaring necessary tables for our app
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

        // Constructor overloading for the use of Design framework
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        // Levereging OnModelCreating method do pre-seed data in our tables
        // and making sure the Emails are unique
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Contact>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "sluzbowy" },
                new Category { Id = 2, Name = "prywatny" },
                new Category { Id = 3, Name = "inny" }
                );

            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory { Id = 1, Name = "none" },
                new Subcategory { Id = 2, Name = "szef" },
                new Subcategory { Id = 3, Name = "klient" }
                );
        }
    }
}
