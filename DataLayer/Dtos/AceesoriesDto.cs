
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer;

namespace ParyanPerfume.Dtos
{
    public class AccesoriesDto : Product
    {
        public int QuantityInCarton { get; set; }
        public int QuantityInPackaging { get; set; }
        public bool ShowInSlider { get; set; }

        [NotMapped]
        public IFormFile? ImageFile{ get; set; }
    }
}