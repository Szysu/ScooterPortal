using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ScooterPortal.ApiService.EntityConfiguration;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .IsRequired();

        builder.Property(x => x.LastName)
            .IsRequired();

        builder.HasMany(x => x.Rentals)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId);
    }
}