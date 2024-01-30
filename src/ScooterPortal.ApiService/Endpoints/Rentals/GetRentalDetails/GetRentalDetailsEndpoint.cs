namespace ScooterPortal.ApiService.Endpoints.Rentals.GetRentalDetails;

public class GetRentalDetailsEndpoint : EndpointWithoutRequest<GetRentalDetailsResponse>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Get("rentals/{id}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var rentalId = Route<int>("id");
        var response = DbContext.Rentals
            .Where(x => x.Id == rentalId)
            .Select(x => new GetRentalDetailsResponse
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Scooter = new()
                {
                    Id = x.Scooter.Id,
                    Model = x.Scooter.Model,
                    Manufacturer = x.Scooter.Manufacturer,
                    BatteryLevel = x.Scooter.BatteryLevel
                },
                Customer = new()
                {
                    Id = x.Customer.Id,
                    FirstName = x.Customer.FirstName,
                    LastName = x.Customer.LastName
                }
            })
            .FirstOrDefault();

        return response is null
            ? SendNotFoundAsync(ct)
            : SendOkAsync(response, ct);
    }
}