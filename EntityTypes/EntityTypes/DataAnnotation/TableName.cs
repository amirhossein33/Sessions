using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.DataAnnotation.B
{
    internal class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

    #region TableName
    [Table("products")]
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
    #endregion
}
