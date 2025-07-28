using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageName { get; set; }

        public ICollection<Perfume> Perfumes { get; set; }
        public ICollection<Bottle> Bottles { get; set; }
        public ICollection<Fixator> Fixators { get; set; }
        public ICollection<Pocket> Pockets { get; set; }
    }
}