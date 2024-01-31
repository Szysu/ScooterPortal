using ScooterPortal.ApiService.Endpoints.Rentals.GetRentalDetails;

namespace ScooterPortal.ApiService.Endpoints.Rentals.CreateRental;

public class CreateRentalEndpoint : Endpoint<CreateRentalRequest>
{
    public DatabaseContext DbContext { get; set; }

    public override void Configure()
    {
        Post("rentals");
    }

    public override Task HandleAsync(CreateRentalRequest req, CancellationToken ct)
    {
        if (!DbContext.Scooters.Any(x => x.Id == req.ScooterId))
        {
            ThrowError(r => r.ScooterId, "Scooter not found");
        }

        if (!DbContext.Customers.Any(x => x.Id == req.CustomerId))
        {
            ThrowError(r => r.CustomerId, "Customer not found");
        }

        var rental = new Rental
        {
            Id = 0,
            ScooterId = req.ScooterId,
            CustomerId = req.CustomerId,
            StartDate = req.StartDate,
            EndDate = req.EndDate
        };

        DbContext.Rentals.Add(rental);
        DbContext.SaveChanges();

        return SendCreatedAtAsync<GetRentalDetailsEndpoint>(new RouteValueDictionary { { "id", rental.Id } }, null, cancellation: ct);
    }
}