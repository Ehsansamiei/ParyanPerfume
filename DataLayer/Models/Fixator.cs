
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Fixator : Product
    {

        public int PricePer20Liters { get; set; }
        public bool IsAlcoholFree { get; set; }
        public bool ShowInSlider { get; set; }
        
    }
}

