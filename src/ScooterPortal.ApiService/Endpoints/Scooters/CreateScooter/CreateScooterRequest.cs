namespace ScooterPortal.ApiService.Endpoints.Scooters.CreateScooter;

public record CreateScooterRequest
{
    public required string Model { get; init; }
    public required string Manufacturer { get; init; }
    public required int BatteryLevel { get; init; }
}