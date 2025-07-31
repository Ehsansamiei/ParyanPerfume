using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public class ParyanPerfumeDbContext : DbContext
    {
        public ParyanPerfumeDbContext(DbContextOptions<ParyanPerfumeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasDiscriminator<string>("ProductType")
                .HasValue<Perfume>("Perfume")
                .HasValue<Bottle>("Bottle")
                .HasValue<Fixator>("Fixator")
                .HasValue<Pocket>("Pocket");

            base.OnModelCreating(modelBuilder);
        }
    }

}