using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Bottle
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public double Volume { get; set; }
        public string? Material { get; set; } // شیشه، پلاستیک، ...
        public string? ImageName { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}