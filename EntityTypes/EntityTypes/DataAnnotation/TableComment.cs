using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.DataAnnotation.ku
{
    internal class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

    #region TableComment
    [Comment("Product managed on the OnlineShop")]
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
    #endregion
}
