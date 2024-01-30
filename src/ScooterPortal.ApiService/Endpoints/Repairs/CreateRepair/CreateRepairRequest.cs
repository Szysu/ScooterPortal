namespace ScooterPortal.ApiService.Endpoints.Repairs.CreateRepair;

public record CreateRepairRequest
{
    public required int ScooterId { get; init; }
    public required string Reason { get; init; }
    public required DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}