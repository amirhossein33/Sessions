using Microsoft.EntityFrameworkCore;

namespace Track
{
    public class NonTrackingOrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasData(
                   new Order { OrderId = 1, Name = @"Test", Price = 5 },
                    new Order { OrderId = 2, Name = @"Test2", Price = 4 });
        }

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFQuerying.Tracking;Trusted_Connection=True;ConnectRetryCount=0")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        #endregion
    }

}
