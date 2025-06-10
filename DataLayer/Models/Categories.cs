using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string CategoryNickName { get; set; }

        public string CategoryDescription { get; set; }

        public string? ImageName { get; set; }

        // Navigation Property
        // Each Product blongs to one Category and each Category can have many Products 
        public virtual ICollection<Products> perfume { get; set; }

        public Categories()
        {
            
        }
    }
}