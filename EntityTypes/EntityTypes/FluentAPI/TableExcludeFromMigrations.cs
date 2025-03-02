using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.FluentAPI.B
{

    internal class MyContext : DbContext
    {
        public DbSet<IdentityUser> Users { get; set; }

        #region TableExcludeFromMigrations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>()
                .ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
        }
        #endregion
    }

    public class IdentityUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
