using Homework21.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homework21.Data.EntityConfigurations
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

