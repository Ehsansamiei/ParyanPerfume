using System.ComponentModel.DataAnnotations;

namespace DataLayer{
    public class Perfumes
    {

        [Key]
        public int PerfumeId { get; set; }

        public int CategoryId { get; set; }

        public string PerfumeName { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }
        
        public string PerfumeBrand  { get; set; }

        public string PerfumeSex { get; set; }

        public int PricePerKilogram { get; set; }

        public int PricePer100gram { get; set; }

        public string ImageName { get; set; }

        public bool ShowInSlider { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModified {get; set;}


        // Navigation Property
        // Each Product blongs to one Category and each Category can have many Products 
        public virtual Categories category { get; set; }

        public Perfumes()
        {
            
        }
    }
}