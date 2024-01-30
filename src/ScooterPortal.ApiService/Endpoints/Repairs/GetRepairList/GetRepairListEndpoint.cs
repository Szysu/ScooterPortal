namespace ScooterPortal.ApiService.Endpoints.Repairs.GetRepairList;

public class GetRepairListEndpoint : EndpointWithoutRequest<List<RepairDto>>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Get("repairs");
    }

    public override Task<List<RepairDto>> ExecuteAsync(CancellationToken ct) =>
        DbContext.Repairs.Select(x => new RepairDto
        {
            Id = x.Id,
            ScooterId = x.ScooterId,
            Reason = x.Reason,
            StartDate = x.StartDate,
            EndDate = x.EndDate
        }).ToListAsync(ct);
}