namespace ScooterPortal.ApiService.Endpoints.Scooters.GetScooterDetails;

public class GetScooterDetailsEndpoint : EndpointWithoutRequest<GetScooterDetailsResponse>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Get("scooters/{id}");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var scooterId = Route<int>("id");
        var response = DbContext.Scooters
            .Where(x => x.Id == scooterId)
            .Select(x => new GetScooterDetailsResponse
            {
                Id = x.Id,
                Model = x.Model,
                Manufacturer = x.Manufacturer,
                BatteryLevel = x.BatteryLevel,
                Rentals = x.Rentals.Select(r => new RentalDto
                {
                    Id = r.Id,
                    CustomerId = r.CustomerId,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate
                }).ToList(),
                Repairs = x.Repairs.Select(r => new RepairDto
                {
                    Id = r.Id,
                    Reason = r.Reason,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate
                }).ToList()
            })
            .FirstOrDefault();

        if (response is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(response, ct);
    }
}