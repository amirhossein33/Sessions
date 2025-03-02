using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ContextPooling;

public class BookLibraryContext : DbContext
{
    public BookLibraryContext(DbContextOptions options)
        : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "C# Programming",
                Author = "John Doe",
                PublishedDate = new DateTime(2020, 1, 1),
                Price = 29.99m
            },
            new Book
            {
                Id = 2,
                Title = "Entity Framework Core",
                Author = "Jane Smith",
                PublishedDate = new DateTime(2021, 5, 15),
                Price = 49.99m
            },
            new Book
            {
                Id = 3,
                Title = "ASP.NET Core for Beginners",
                Author = "James Brown",
                PublishedDate = new DateTime(2022, 7, 20),
                Price = 39.99m
            });
    }
}

