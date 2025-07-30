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
        public ParyanPerfumeDbContext(DbContextOptions<ParyanPerfumeDbContext> option) : base(option)
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Perfume> perfumes { get; set; }
        public DbSet<Bottle> bottles { get; set; }
        public DbSet<Fixator> fixators { get; set; }
        public DbSet<Pocket> pockets { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<Perfume>(c =>
            // {
            //     c.HasOne(c => c.Category)
            //     .WithMany(c => c.Perfumes)
            //     .HasForeignKey(c => c.CategoryId);
            // });
            builder.Entity<Bottle>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Bottles)
                .HasForeignKey(b => b.CategoryId);

            builder.Entity<Fixator>()
                .HasOne(f => f.Category)
                .WithMany(c => c.Fixators)
                .HasForeignKey(f => f.CategoryId);

            builder.Entity<Pocket>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Pockets)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}