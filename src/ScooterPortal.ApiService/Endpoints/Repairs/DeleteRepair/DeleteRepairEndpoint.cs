namespace ScooterPortal.ApiService.Endpoints.Repairs.DeleteRepair;

public class DeleteRepairEndpoint : EndpointWithoutRequest
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Delete("repairs/{id}");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var repairId = Route<int>("id");
        var repair = DbContext.Repairs.FirstOrDefault(x => x.Id == repairId);

        if (repair is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        DbContext.Repairs.Remove(repair);
        await DbContext.SaveChangesAsync(ct);

        await SendNoContentAsync(ct);
    }
}