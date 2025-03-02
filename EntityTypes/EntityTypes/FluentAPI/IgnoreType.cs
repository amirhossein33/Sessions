using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.FluentAPI.J
{
    internal class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        #region IgnoreType
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ProductMetadata>();
        }
        #endregion
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public ProductMetadata Metadata { get; set; }
    }

    public class ProductMetadata
    {
        public DateTime LoadedFromDatabase { get; set; }
    }
}
