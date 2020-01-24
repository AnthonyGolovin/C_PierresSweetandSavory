using System.Collections.Generic;

namespace SweetAndSavory.Models
{
  public class Flavor
    {
        public Flavor()
        {
            this.Books = new HashSet<FlavorTreat>();
        }

        public int FlavorId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<FlavorTreat> Treat { get; set; }
    }
}