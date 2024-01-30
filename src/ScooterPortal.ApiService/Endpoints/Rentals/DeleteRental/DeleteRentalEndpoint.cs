namespace ScooterPortal.ApiService.Endpoints.Rentals.DeleteRental;

public class DeleteRentalEndpoint : EndpointWithoutRequest
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Delete("rentals/{id}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var rentalId = Route<int>("id");
        var rental = DbContext.Rentals.FirstOrDefault(x => x.Id == rentalId);

        if (rental is null)
        {
            return SendNotFoundAsync(ct);
        }

        DbContext.Rentals.Remove(rental);
        DbContext.SaveChanges();

        return SendNoContentAsync(ct);
    }
}