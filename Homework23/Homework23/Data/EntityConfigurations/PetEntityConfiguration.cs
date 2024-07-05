using Homework23.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homework23.Data.EntityConfigurations
{
    public class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.CategoryId).IsRequired();
            builder.Property(b => b.BreedId).IsRequired();
            builder.Property(b => b.LocationId)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(p => p.Pet)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Breed)
                .WithMany(p => p.Pet)
                .HasForeignKey(p => p.BreedId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Location)
                .WithMany(p => p.Pet)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

