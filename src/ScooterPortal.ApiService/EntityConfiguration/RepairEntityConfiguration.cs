using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ScooterPortal.ApiService.EntityConfiguration;

public class RepairEntityConfiguration : IEntityTypeConfiguration<Repair>
{
    public void Configure(EntityTypeBuilder<Repair> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ScooterId)
            .IsRequired();

        builder.Property(x => x.Reason)
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired(false);

        builder.HasOne(x => x.Scooter)
            .WithMany(x => x.Repairs)
            .HasForeignKey(x => x.ScooterId);
    }
}