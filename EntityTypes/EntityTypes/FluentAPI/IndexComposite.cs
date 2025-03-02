using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes.EntityTypes.FluentAPI.Index
{
    internal class MyContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        #region Composite
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasIndex(p => new { p.FirstName, p.LastName });
        }
        #endregion
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
