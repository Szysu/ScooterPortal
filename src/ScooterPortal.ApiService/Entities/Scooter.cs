namespace ScooterPortal.ApiService.Entities;

public class Scooter : Entity
{
    public required string Model { get; set; }
    public required string Manufacturer { get; set; }
    public required int BatteryLevel { get; set; }

    public virtual List<Rental> Rentals { get; set; } = [];
    public virtual List<Repair> Repairs { get; set; } = [];
}