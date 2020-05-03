using System.Collections.Generic;

namespace Labb2.Models
{
    public class Laptop
    {
        public Laptop()

        {

            LaptopFeature = new List<LaptopFeatures>();

        }
        public int Id { get; set; }

        public int ModelId { get; set; }

        public int CpuId { get; set; }

        public int ColorId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Color Color { get; set; }

        public virtual Country Country { get; set; }

        public virtual Processor Cpu { get; set; }

        public virtual Producer Model { get; set; }

        public virtual ICollection<LaptopFeatures> LaptopFeature { get; set; }
    }
}
