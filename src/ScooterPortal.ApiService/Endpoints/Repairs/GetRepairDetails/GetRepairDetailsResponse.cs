namespace ScooterPortal.ApiService.Endpoints.Repairs.GetRepairDetails;

public record GetRepairDetailsResponse
{
    public required int Id { get; init; }
    public required string Reason { get; init; }
    public required DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }

    public required ScooterDto Scooter { get; init; }
}

public record ScooterDto
{
    public required int Id { get; init; }
    public required string Model { get; init; }
    public required string Manufacturer { get; init; }
    public required int BatteryLevel { get; init; }
}