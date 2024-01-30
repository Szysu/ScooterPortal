namespace ScooterPortal.ApiService.Endpoints.Repairs.GetRepairList;

public record RepairDto
{
    public required int Id { get; init; }
    public required int ScooterId { get; init; }
    public required string Reason { get; init; } = null!;
    public required DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}