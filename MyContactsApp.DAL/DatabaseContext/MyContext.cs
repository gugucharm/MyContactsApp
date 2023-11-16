using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.Models;

namespace MyContactsApp.DAL.DatabaseContext
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Contact>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "sluzbowy" },
                new Category { Id = 2, Name = "prywatny" },
                new Category { Id = 3, Name = "inny" }
                );
        }
    }
}
