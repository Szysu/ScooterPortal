using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ScooterPortal.ApiService.EntityConfiguration;

public class ScooterEntityConfiguration : IEntityTypeConfiguration<Scooter>
{
    public void Configure(EntityTypeBuilder<Scooter> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Model)
            .IsRequired();

        builder.Property(x => x.Manufacturer)
            .IsRequired();

        builder.Property(x => x.BatteryLevel)
            .IsRequired();

        builder.HasMany(x => x.Rentals)
            .WithOne(x => x.Scooter)
            .HasForeignKey(x => x.ScooterId);

        builder.HasMany(x => x.Repairs)
            .WithOne(x => x.Scooter)
            .HasForeignKey(x => x.ScooterId);
    }
}