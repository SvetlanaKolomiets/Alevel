using Homework23.Data.Entities;
using Homework23.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Homework23.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BreedEntity> Breeds { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<PetEntity> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BreedEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PetEntityConfiguration());
            modelBuilder.UseHiLo();
        }
    }
}

