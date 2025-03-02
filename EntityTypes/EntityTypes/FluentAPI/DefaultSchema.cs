using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.FluentAPI.Z
{
    internal class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        #region DefaultSchema
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("shopping");
        }
        #endregion
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
