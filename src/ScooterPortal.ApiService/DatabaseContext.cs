using ScooterPortal.ApiService.EntityConfiguration;

namespace ScooterPortal.ApiService;

public class DatabaseContext : DbContext
{
    public required DbSet<Administrator> Administrators { get; set; }
    public required DbSet<Customer> Customers { get; set; }
    public required DbSet<Rental> Rentals { get; set; }
    public required DbSet<Repair> Repairs { get; set; }
    public required DbSet<Scooter> Scooters { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdministratorEntityConfiguration).Assembly);
    }
}