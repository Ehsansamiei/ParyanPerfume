using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Bottle : Product
    {
        
        public double Volume { get; set; }
        public int QuantityInCarton { get; set; }
        public int QuantityInPackaging { get; set; }
        public string? Material { get; set; } 

    }

}