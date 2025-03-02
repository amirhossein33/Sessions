using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.FluentAPI
{
    internal class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        #region TableNameAndSchema
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("products", schema: "shoping");
        }
        #endregion
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
