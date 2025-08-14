using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer;

namespace ParyanPerfume.Dtos
{
    public class BottlesDto : Product
    {
        
        public double Volume { get; set; }
        public int QuantityInCarton { get; set; }
        public int QuantityInPackaging { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? Material { get; set; } 

    }

}