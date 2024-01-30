namespace ScooterPortal.ApiService.Endpoints.Repairs.UpdateRepair;

public class UpdateRepairEndpoint : Endpoint<UpdateRepairRequest>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Put("repairs/{id}");
    }

    public override async Task HandleAsync(UpdateRepairRequest req, CancellationToken ct)
    {
        var repairId = Route<int>("id");
        var repair = DbContext.Repairs.FirstOrDefault(x => x.Id == repairId);

        if (repair is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        repair.Reason = req.Reason;
        repair.StartDate = req.StartDate;
        repair.EndDate = req.EndDate;

        await DbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}