namespace ScooterPortal.ApiService.Endpoints.Rentals.GetRentalDetails;

public record GetRentalDetailsResponse
{
    public required int Id { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public required ScooterDto Scooter { get; set; }
    public required CustomerDto Customer { get; set; }
}

public record ScooterDto
{
    public required int Id { get; set; }
    public required string Model { get; set; }
    public required string Manufacturer { get; set; }
    public required int BatteryLevel { get; set; }
}

public record CustomerDto
{
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}