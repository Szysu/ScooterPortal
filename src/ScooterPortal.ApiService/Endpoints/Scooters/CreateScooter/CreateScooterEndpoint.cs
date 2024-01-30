using ScooterPortal.ApiService.Endpoints.Scooters.GetScooterDetails;

namespace ScooterPortal.ApiService.Endpoints.Scooters.CreateScooter;

public class CreateScooterEndpoint : Endpoint<CreateScooterRequest>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Post("scooters");
    }

    public override Task HandleAsync(CreateScooterRequest req, CancellationToken ct)
    {
        var scooter = new Scooter
        {
            Id = 0,
            Model = req.Model,
            Manufacturer = req.Manufacturer,
            BatteryLevel = req.BatteryLevel
        };

        DbContext.Scooters.Add(scooter);
        DbContext.SaveChanges();

        return SendCreatedAtAsync<GetScooterDetailsEndpoint>(scooter.Id, null, cancellation: ct);
    }
}