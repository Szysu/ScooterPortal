namespace ScooterPortal.ApiService.Endpoints.Scooters.UpdateScooter;

public record UpdateScooterRequest
{
    public required string Model { get; set; }
    public required string Manufacturer { get; set; }
    public required int BatteryLevel { get; set; }
}