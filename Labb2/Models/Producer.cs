using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb2.Models
{
    public class Producer

    {

        public Producer()

        {

            Laptop = new List<Laptop>();

        }

        public int Id { get; set; }

        public string Model { get; set; }

        public virtual ICollection<Laptop> Laptop { get; set; }

    }
}
