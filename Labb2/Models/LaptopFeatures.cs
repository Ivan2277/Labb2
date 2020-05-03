namespace Labb2.Models
{
    public class LaptopFeatures
    {
        public int Id { get; set; }

        public int FeatureId { get; set; }

        public int LaptopId { get; set; }

        public virtual Feature Feature { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}
