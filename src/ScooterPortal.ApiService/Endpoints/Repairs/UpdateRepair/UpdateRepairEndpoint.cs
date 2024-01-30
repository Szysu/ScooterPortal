namespace ScooterPortal.ApiService.Endpoints.Repairs.UpdateRepair;

public class UpdateRepairEndpoint : Endpoint<UpdateRepairRequest>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Put("repairs/{id}");
    }

    public override Task HandleAsync(UpdateRepairRequest req, CancellationToken ct)
    {
        var repairId = Route<int>("id");
        var repair = DbContext.Repairs.FirstOrDefault(x => x.Id == repairId);

        if (repair is null)
        {
            return SendNotFoundAsync(ct);
        }

        if (!DbContext.Scooters.Any(x => x.Id == req.ScooterId))
        {
            ThrowError(r => r.ScooterId, "Scooter not found");
        }

        repair.Reason = req.Reason;
        repair.StartDate = req.StartDate;
        repair.EndDate = req.EndDate;

        DbContext.SaveChanges();
        return SendNoContentAsync(ct);
    }
}