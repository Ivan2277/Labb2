using System.Collections.Generic;

namespace Labb2.Models
{
    public class Country
    {
        public Country()
        {
            Laptop = new List<Laptop>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptop { get; set; }
    }
}
