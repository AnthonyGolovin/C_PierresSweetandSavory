using System.Collections.Generic;

namespace SweetAndSavory.Models
{
    public class Treat
    {
        public Treat()
        {
            this.Flavor = new HashSet<FlavorTreat>();
        }

        public int TreatId { get; set; }
        public string Description { get; set; }
        public int FlavorId { get; set; } 
        public virtual Flavor Flavor { get; set; }
        public virtual ApplicationUser User { get; set; } 
        // public bool isChecked = false;

        public ICollection<FlavorTreat> Flavors { get;}
    }
}