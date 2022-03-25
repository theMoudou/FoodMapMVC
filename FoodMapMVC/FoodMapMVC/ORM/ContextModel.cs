using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FoodMapMVC.ORM
{
    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=ContextModel")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<MapContent> MapContents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Account1)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.PWD)
                .IsUnicode(false);

            modelBuilder.Entity<MapContent>()
                .Property(e => e.CoverImage)
                .IsUnicode(false);
        }
    }
}
