namespace OnlineShop.Infra
{
    using global::OnlineShop.Core.Entities;
    using Microsoft.EntityFrameworkCore;

    namespace OnlineShop.Infrastructure.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Order> Orders { get; set; }
            public DbSet<Customer> Customers { get; set; }
            // سایر DbSet ها
        }
    }


}

