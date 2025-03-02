using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.FluentAPI.A
{

    internal class MyContext : DbContext
    {
        public DbSet<Product> products { get; set; }

        #region TableName
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Product");
        }
        #endregion
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
