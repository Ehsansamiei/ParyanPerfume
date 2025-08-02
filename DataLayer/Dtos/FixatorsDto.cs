using System.ComponentModel.DataAnnotations.Schema;
using DataLayer;

namespace ParyanPerfume.Dtos
{
    public class FixatorsDto : Product
    {
        public int PricePer20Liters { get; set; }
        public bool IsAlcoholFree { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public bool ShowInSlider { get; set; }
    }
}