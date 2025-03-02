using Microsoft.EntityFrameworkCore;

namespace ContextPoolingWithState
{

        public class LibraryContext : DbContext
        {
            public int TenantId { get; set; }

            public LibraryContext(DbContextOptions options)
                : base(options)
            {
            }

            public DbSet<Book> Books { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Book>()
                    .HasQueryFilter(b => b.TenantId == TenantId)
                    .HasData(
                        new Book
                        {
                            Id = 1,
                            TenantId = 0,
                            Title = "C# Programming",
                            Author = "John Doe",
                            PublishedDate = new DateTime(2020, 1, 1),
                            Price = 29.99m
                        },
                        new Book
                        {
                            Id = 2,
                            TenantId = 0,
                            Title = "Learning ASP.NET Core",
                            Author = "Jane Smith",
                            PublishedDate = new DateTime(2021, 5, 1),
                            Price = 39.99m
                        },
                        new Book
                        {
                            Id = 3,
                            TenantId = 1,
                            Title = "Introduction to Machine Learning",
                            Author = "Alice Brown",
                            PublishedDate = new DateTime(2022, 8, 1),
                            Price = 49.99m
                        });
        }
    }
}