using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ScooterPortal.ApiService.EntityConfiguration;

public class RentalEntityConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ScooterId)
            .IsRequired();

        builder.Property(x => x.CustomerId)
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired(false);

        builder.HasOne(x => x.Scooter)
            .WithMany(x => x.Rentals)
            .HasForeignKey(x => x.ScooterId);
    }
}