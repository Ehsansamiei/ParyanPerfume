

using System.ComponentModel.DataAnnotations.Schema;

namespace ParyanPerfume.Dtos
{
    public class ProductsDto
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string ProductNickName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public string ShortDescription { get; set; } = string.Empty;
        
        public string ProductBrand  { get; set; } = string.Empty;

        public string ProductSex { get; set; } = string.Empty;

        public int Price { get; set; }

        public int PricePer100gram { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string? ImageName { get; set; }

        public bool ShowInSlider { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModified {get; set;}
    }
}