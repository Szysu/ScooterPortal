namespace ScooterPortal.ApiService.Endpoints.Rentals.UpdateRental;

public class UpdateRentalEndpoint : Endpoint<UpdateRentalRequest>
{
    public DatabaseContext DbContext { get; set; }

    public override void Configure()
    {
        Put("rentals/{id}");
    }

    public override Task HandleAsync(UpdateRentalRequest req, CancellationToken ct)
    {
        var rentalId = Route<int>("id");
        var rental = DbContext.Rentals.FirstOrDefault(x => x.Id == rentalId);

        if (rental is null)
        {
            return SendNotFoundAsync(ct);
        }

        if (!DbContext.Scooters.Any(x => x.Id == req.ScooterId))
        {
            ThrowError(r => r.ScooterId, "Scooter not found");
        }

        if (!DbContext.Customers.Any(x => x.Id == req.CustomerId))
        {
            ThrowError(r => r.CustomerId, "Customer not found");
        }

        rental.ScooterId = req.ScooterId;
        rental.CustomerId = req.CustomerId;
        rental.StartDate = req.StartDate;
        rental.EndDate = req.EndDate;

        DbContext.SaveChanges();

        return SendNoContentAsync(ct);
    }
}