namespace ScooterPortal.ApiService.Endpoints.Scooters.GetScooterDetails;

public record GetScooterDetailsResponse
{
    public required int Id { get; init; }
    public required string Model { get; init; }
    public required string Manufacturer { get; init; }
    public required int BatteryLevel { get; init; }

    public required List<RentalDto> Rentals { get; init; }
    public required List<RepairDto> Repairs { get; init; }
}

public record RentalDto
{
    public required int Id { get; init; }
    public required int CustomerId { get; init; }
    public required DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}

public record RepairDto
{
    public required int Id { get; init; }
    public required string Reason { get; init; }
    public required DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}