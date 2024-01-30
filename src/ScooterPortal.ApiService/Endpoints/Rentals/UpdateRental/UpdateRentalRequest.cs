namespace ScooterPortal.ApiService.Endpoints.Rentals.UpdateRental;

public record UpdateRentalRequest
{
    public required int ScooterId { get; init; }
    public required int CustomerId { get; init; }
    public required DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}