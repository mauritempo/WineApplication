using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WineContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wine> Wines { get; set; }

        public DbSet<Cata> Catas { get; set; }
        public WineContext(DbContextOptions<WineContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Cata>()
                .HasMany(c => c.Vinos)
                .WithMany(w => w.Catas)
                .UsingEntity(j => j.ToTable("CataWines")); 
        }
    }
}
