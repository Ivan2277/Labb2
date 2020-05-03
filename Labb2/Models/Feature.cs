using System.Collections.Generic;

namespace Labb2.Models
{
    public class Feature

    {

        public Feature()

        {

            LaptopFeature = new List<LaptopFeatures>();

        }



        public int Id { get; set; }

        public string Feature1 { get; set; }

        public virtual ICollection<LaptopFeatures> LaptopFeature { get; set; }

    }
}
