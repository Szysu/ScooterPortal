using ScooterPortal.ApiService.Endpoints.Repairs.GetRepairDetails;

namespace ScooterPortal.ApiService.Endpoints.Repairs.CreateRepair;

public class CreateRepairEndpoint : Endpoint<CreateRepairRequest>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Post("repairs");
    }

    public override Task HandleAsync(CreateRepairRequest req, CancellationToken ct)
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

        return SendCreatedAtAsync<GetRepairDetailsEndpoint>(new RouteValueDictionary { { "id", repair.Id } }, null, cancellation: ct);
    }
}