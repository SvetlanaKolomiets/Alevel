using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Homework23.Data.Entities;

namespace Homework23.Data.EntityConfigurations
{
    public class BreedEntityConfiguration : IEntityTypeConfiguration<BreedEntity>
    {
        public void Configure(EntityTypeBuilder<BreedEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.BreedName)
                .IsRequired();

            builder.HasOne(b => b.Category)
                .WithMany(b => b.Breeds)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

