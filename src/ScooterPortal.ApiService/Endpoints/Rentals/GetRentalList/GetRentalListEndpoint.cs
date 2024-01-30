namespace ScooterPortal.ApiService.Endpoints.Rentals.GetRentalList;

public class GetRentalListEndpoint : EndpointWithoutRequest<List<RentalDto>>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Get("rentals");
    }

    public override Task<List<RentalDto>> ExecuteAsync(CancellationToken ct) =>
        DbContext.Rentals.Select(x => new RentalDto
        {
            Id = x.Id,
            ScooterId = x.ScooterId,
            CustomerId = x.CustomerId,
            StartDate = x.StartDate,
            EndDate = x.EndDate
        }).ToListAsync(ct);
}