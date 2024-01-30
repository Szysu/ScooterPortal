namespace ScooterPortal.ApiService.Endpoints.Repairs.DeleteRepair;

public class DeleteRepairEndpoint : EndpointWithoutRequest
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Delete("repairs/{id}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var repairId = Route<int>("id");
        var repair = DbContext.Repairs.FirstOrDefault(x => x.Id == repairId);

        if (repair is null)
        {
            return SendNotFoundAsync(ct);
        }

        DbContext.Repairs.Remove(repair);
        DbContext.SaveChanges();

        return SendNoContentAsync(ct);
    }
}