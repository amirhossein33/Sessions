using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes
{
    #region EntityTypes
    internal class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditEntry>();
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Description { get; set; }

        public Product Product { get; set; }
    }

    public class AuditEntry
    {
        public int AuditEntryId { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
    }
    #endregion

    #region ProductWithMultipleOrdersEntity
    public class ProductWithMultipleOrders
    {
        public string Name { get; set; }
        public int OrderCount { get; set; }
    }
    #endregion

    public class MyContextWithFunctionMapping : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region QueryableFunctionConfigurationToFunction
            modelBuilder.Entity<ProductWithMultipleOrders>().HasNoKey().ToFunction("ProductsWithMultipleOrders");
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EFModeling.EntityTypeToFunctionMapping;Trusted_Connection=True;ConnectRetryCount=0");
        }
    }

}
