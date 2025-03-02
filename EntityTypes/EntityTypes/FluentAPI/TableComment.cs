using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.FluentAPI.C
{
    internal class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        #region TableComment
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(
                tableBuilder => tableBuilder.HasComment("Products managed on the ShopStore"));
        }
        #endregion
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }

}
