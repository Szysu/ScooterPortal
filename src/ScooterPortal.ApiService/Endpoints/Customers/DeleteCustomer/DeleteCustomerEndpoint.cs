namespace ScooterPortal.ApiService.Endpoints.Customers.DeleteCustomer;

public class DeleteCustomerEndpoint : EndpointWithoutRequest
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Delete("customers/{id}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var customerId = Route<int>("id");
        var customer = DbContext.Customers.FirstOrDefault(x => x.Id == customerId);

        if (customer is null)
        {
            return SendNotFoundAsync(ct);
        }

        DbContext.Customers.Remove(customer);
        DbContext.SaveChanges();

        return SendNoContentAsync(ct);
    }
}