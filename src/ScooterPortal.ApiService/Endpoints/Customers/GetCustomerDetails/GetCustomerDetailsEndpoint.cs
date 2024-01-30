namespace ScooterPortal.ApiService.Endpoints.Customers.GetCustomerDetails;

public class GetCustomerDetailsEndpoint : EndpointWithoutRequest<GetCustomerDetailsResponse>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Get("customers/{id}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var customerId = Route<int>("id");
        var response = DbContext.Customers
            .Where(x => x.Id == customerId)
            .Select(x => new GetCustomerDetailsResponse
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Rentals = x.Rentals.Select(r => new RentalDto
                {
                    Id = r.Id,
                    ScooterId = r.ScooterId,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate
                }).ToList()
            })
            .FirstOrDefault();

        return response is null
            ? SendNotFoundAsync(ct)
            : SendOkAsync(response, ct);
    }
}