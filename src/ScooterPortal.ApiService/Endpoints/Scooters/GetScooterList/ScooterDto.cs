namespace ScooterPortal.ApiService.Endpoints;

public record ScooterDto
{
    public required int Id { get; init; }
    public required string Model { get; init; }
    public required string Manufacturer { get; init; }
    public required int BatteryLevel { get; init; }
}