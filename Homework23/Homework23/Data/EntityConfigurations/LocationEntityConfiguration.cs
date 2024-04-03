using Homework23.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homework23.Data.EntityConfigurations
{
    public class LocationEntityConfiguration : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(EntityTypeBuilder<LocationEntity> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.LocationName)
                .IsRequired();
        }
    }
}

