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

        
        public DbSet<Perfume> perfumes { get; set; }
        public DbSet<Bottle> bottles { get; set; }
        public DbSet<Fixator> fixators { get; set; }
        public DbSet<Pocket> pockets { get; set; }
    }
}