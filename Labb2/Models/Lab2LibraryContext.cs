using Microsoft.EntityFrameworkCore;

namespace Labb2.Models
{
    public class Lab2LibraryContext : DbContext
    {
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Laptop> Laptops { get; set; }
        public virtual DbSet<LaptopFeatures> LaptopFeatures { get; set; }
        public virtual DbSet<Processor> CPU { get; set; }
        public virtual DbSet<Producer> Models { get; set; }

        public Lab2LibraryContext(DbContextOptions<Lab2LibraryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
