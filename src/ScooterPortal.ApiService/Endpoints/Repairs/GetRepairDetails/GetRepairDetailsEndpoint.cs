namespace ScooterPortal.ApiService.Endpoints.Repairs.GetRepairDetails;

public class GetRepairDetailsEndpoint : EndpointWithoutRequest<GetRepairDetailsResponse>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Get("repairs/{id}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var repairId = Route<int>("id");
        var response = DbContext.Repairs
            .Where(x => x.Id == repairId)
            .Select(x => new GetRepairDetailsResponse
            {
                Id = x.Id,
                Reason = x.Reason,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Scooter = new()
                {
                    Id = x.Scooter.Id,
                    Model = x.Scooter.Model,
                    Manufacturer = x.Scooter.Manufacturer,
                    BatteryLevel = x.Scooter.BatteryLevel
                }
            })
            .FirstOrDefault();

        return response is null
            ? SendNotFoundAsync(ct)
            : SendOkAsync(response, ct);
    }
}