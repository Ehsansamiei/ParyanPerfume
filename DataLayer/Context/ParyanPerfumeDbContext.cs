using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer{

    public class ParyanPerfumeDbContext : DbContext
    {
        public ParyanPerfumeDbContext(DbContextOptions<ParyanPerfumeDbContext> option) : base(option)
        {
        }

        public DbSet<Categories> category{ get; set; }
        public DbSet<Perfumes> perfume { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Perfumes>(c => {
                c.HasOne(c => c.category)
                .WithMany(c => c.perfume)
                .HasForeignKey(c => c.CategoryId);
            });
        }
    }
}