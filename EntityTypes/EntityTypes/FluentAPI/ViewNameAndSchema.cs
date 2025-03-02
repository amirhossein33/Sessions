using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.FluentAPI.ki

{
    internal class MyContext : DbContext
    {
        public DbSet<Product> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ViewNameAndSchema
            modelBuilder.Entity<Product>()
                .ToView("productsView", schema: "shopping");
            #endregion
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
