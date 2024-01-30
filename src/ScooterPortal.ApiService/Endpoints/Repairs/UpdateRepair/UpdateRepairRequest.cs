namespace ScooterPortal.ApiService.Endpoints.Repairs.UpdateRepair;

public record UpdateRepairRequest
{
    public required string Reason { get; init; }
    public required DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}