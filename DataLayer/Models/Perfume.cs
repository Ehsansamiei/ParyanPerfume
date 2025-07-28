using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class Perfume
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PricePer100gram { get; set; }
        public string Brand { get; set; }
        public string Gender { get; set; }
        public string? ImageName { get; set; }
        public bool ShowInSlider { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}