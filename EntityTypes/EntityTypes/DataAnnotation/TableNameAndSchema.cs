using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.DataAnnotation.C11
{
    internal class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

    #region TableNameAndSchema
    [Table("products", Schema = "shopping")]
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
    #endregion
}
