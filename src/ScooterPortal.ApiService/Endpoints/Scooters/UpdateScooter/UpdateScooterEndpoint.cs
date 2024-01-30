namespace ScooterPortal.ApiService.Endpoints.Scooters.UpdateScooter;

public class UpdateScooterEndpoint : Endpoint<UpdateScooterRequest>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Put("scooters/{id}");
    }

    public override Task HandleAsync(UpdateScooterRequest req, CancellationToken ct)
    {
        var scooterId = Route<int>("id");
        var scooter = DbContext.Scooters.FirstOrDefault(x => x.Id == scooterId);

        if (scooter is null)
        {
            return SendNotFoundAsync(ct);
        }

        scooter.Model = req.Model;
        scooter.Manufacturer = req.Manufacturer;
        scooter.BatteryLevel = req.BatteryLevel;

        DbContext.SaveChanges();
        return SendNoContentAsync(ct);
    }
}