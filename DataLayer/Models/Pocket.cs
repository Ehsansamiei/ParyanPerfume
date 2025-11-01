using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Pocket : Product
    {
        
        public int QuantityInCarton { get; set; }
        public int QuantityInPackaging { get; set; }
        public bool ShowInSlider { get; set; }

    }
}