namespace ScooterPortal.ApiService.Endpoints.Customers.UpdateCustomer;

public class UpdateCustomerEndpoint : Endpoint<UpdateCustomerRequest>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Put("customers/{id}");
    }

    public override Task HandleAsync(UpdateCustomerRequest req, CancellationToken ct)
    {
        var customerId = Route<int>("id");
        var customer = DbContext.Customers.FirstOrDefault(x => x.Id == customerId);

        if (customer is null)
        {
            return SendNotFoundAsync(ct);
        }

        customer.FirstName = req.FirstName;
        customer.LastName = req.LastName;

        DbContext.SaveChanges();

        return SendNoContentAsync(ct);
    }
}