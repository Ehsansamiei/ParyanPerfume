using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public abstract class Product
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string? ImageName { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}