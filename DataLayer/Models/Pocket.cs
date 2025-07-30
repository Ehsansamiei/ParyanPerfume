using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Pocket
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string? ImageName { get; set; }
        public bool ShowInSlider { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
       

    }
}