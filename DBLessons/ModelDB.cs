using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DBLessons
{
    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=ModelDB")
        {
        }

        public virtual DbSet<Items_pay> Items_pay { get; set; }
        public virtual DbSet<Pay> Pay { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items_pay>()
                .Property(e => e.Item_sum)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pay>()
                .Property(e => e.Sum_pay)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pay>()
                .HasMany(e => e.Items_pay)
                .WithRequired(e => e.Pay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Pay)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);
        }
    }
}
