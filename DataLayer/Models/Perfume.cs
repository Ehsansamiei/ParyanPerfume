using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class Perfume : Product
    {

        public int PricePer100gram { get; set; }
        public string Gender { get; set; } = string.Empty;
        public bool ShowInSlider { get; set; }
        
    }
}