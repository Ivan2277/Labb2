using System.Collections.Generic;

namespace Labb2.Models
{
    public class Color
    {
        public Color()

        {

            Laptop = new List<Laptop>();

        }

        public int Id { get; set; }

        public string Color1 { get; set; }

        public virtual ICollection<Laptop> Laptop { get; set; }
    }
}

