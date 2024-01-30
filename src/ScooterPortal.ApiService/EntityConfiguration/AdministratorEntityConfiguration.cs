using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ScooterPortal.ApiService.EntityConfiguration;

public class AdministratorEntityConfiguration : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .IsRequired();

        builder.Property(x => x.LastName)
            .IsRequired();

        builder.Property(x => x.Username)
            .IsRequired();

        builder.Property(x => x.Password)
            .IsRequired();
    }
}