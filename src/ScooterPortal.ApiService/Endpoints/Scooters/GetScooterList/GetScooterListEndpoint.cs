namespace ScooterPortal.ApiService.Endpoints.Scooters.GetScooterList;

public class GetScooterListEndpoint : EndpointWithoutRequest<List<ScooterDto>>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Get("scooters");
    }

    public override Task<List<ScooterDto>> ExecuteAsync(CancellationToken ct) =>
        DbContext.Scooters.Select(x => new ScooterDto
        {
            Id = x.Id,
            Model = x.Model,
            Manufacturer = x.Manufacturer,
            BatteryLevel = x.BatteryLevel
        }).ToListAsync(ct);
}