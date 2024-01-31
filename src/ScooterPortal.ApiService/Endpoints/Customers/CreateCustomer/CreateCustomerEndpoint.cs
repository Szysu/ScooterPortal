using ScooterPortal.ApiService.Endpoints.Customers.GetCustomerDetails;

namespace ScooterPortal.ApiService.Endpoints.Customers.CreateCustomer;

public class CreateCustomerEndpoint : Endpoint<CreateCustomerRequest>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Post("customers");
    }

    public override Task HandleAsync(CreateCustomerRequest req, CancellationToken ct)
    {
        var customer = new Customer
        {
            Id = 0,
            FirstName = req.FirstName,
            LastName = req.LastName
        };

        DbContext.Customers.Add(customer);
        DbContext.SaveChanges();

        return SendCreatedAtAsync<GetCustomerDetailsEndpoint>(new RouteValueDictionary { { "id", customer.Id } }, null, cancellation: ct);
    }
}