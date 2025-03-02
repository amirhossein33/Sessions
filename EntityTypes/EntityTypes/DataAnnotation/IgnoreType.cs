using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.DataAnnotation
{
    internal class MyContext : DbContext
    {
        public DbSet<Product> Blogs { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public ProductMetadata Metadata { get; set; }
    }

    #region IgnoreType
    [NotMapped]
    public class ProductMetadata
    {
        public DateTime LoadedFromDatabase { get; set; }
    }
    #endregion
}
