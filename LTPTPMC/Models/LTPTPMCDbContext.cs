using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LTPTPMC.Models
{
    public partial class LTPTPMCDbContext : DbContext
    {
        public LTPTPMCDbContext()
            : base("name=LTPTPMC")
        {
        }


        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Demo> Demos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>()
                 .Property(e => e.CCCD)
                 .IsUnicode(false);
            modelBuilder.Entity<Person>()
                 .Property(e => e.FullName)
                 .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<LTPTPMC.Models.Student> People { get; set; }
    }
}
