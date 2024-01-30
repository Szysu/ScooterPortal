namespace ScooterPortal.ApiService.Endpoints.Rentals.GetRentalList;

public record RentalDto
{
    public required int Id { get; init; }
    public required int ScooterId { get; init; }
    public required int CustomerId { get; init; }
    public required DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}