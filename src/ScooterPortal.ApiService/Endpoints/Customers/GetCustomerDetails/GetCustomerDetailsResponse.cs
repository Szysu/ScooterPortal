namespace ScooterPortal.ApiService.Endpoints.Customers.GetCustomerDetails;

public record GetCustomerDetailsResponse
{
    public required int Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }

    public required List<RentalDto> Rentals { get; init; }
}

public record RentalDto
{
    public required int Id { get; init; }
    public required int ScooterId { get; init; }
    public required DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}