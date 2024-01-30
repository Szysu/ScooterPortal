using ScooterPortal.ApiService.Endpoints.Repairs.GetRepairDetails;

namespace ScooterPortal.ApiService.Endpoints.Repairs.AddRepair;

public class AddRepairEndpoint : Endpoint<AddRepairRequest>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Post("repairs");
    }

    public override Task HandleAsync(AddRepairRequest req, CancellationToken ct)
    {
        if (!DbContext.Scooters.Any(x => x.Id == req.ScooterId))
        {
            ThrowError(r => r.ScooterId, "Scooter not found");
        }

        var repair = new Repair
        {
            Id = 0,
            ScooterId = req.ScooterId,
            Reason = req.Reason,
            StartDate = req.StartDate,
            EndDate = req.EndDate
        };

        DbContext.Repairs.Add(repair);
        DbContext.SaveChanges();

        return SendCreatedAtAsync<GetRepairDetailsEndpoint>(repair.Id, null, cancellation: ct);
    }
}