using BookAPI.Data.Entities;
using BookAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Author).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.ISBN).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Genre).IsRequired();
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().HasAlternateKey(b => b.ISBN);
            modelBuilder.Entity<Book>().ToTable("Libary_Archive");

            // Test data for non-empty DB
            var book1 = new Book()
            {
                Id = 1,
                Title = "CLR via C#",
                Author = "Jeffrey Richter",
                Genre = "Educational",
                ISBN = "4-7650-21",
                Description = "The book about C# and .NET"
            };
            var book2 = new Book()
            {
                Id = 2,
                Title = "C++ Programming",
                Author = "Lafore Robert",
                Genre = "Educational",
                ISBN = "4-5421-61",
                Description = "The book about C++, STL and basic algorithms"
            };

            modelBuilder.Entity<Book>().HasData(book1);
            modelBuilder.Entity<Book>().HasData(book2);
        }
    }
}