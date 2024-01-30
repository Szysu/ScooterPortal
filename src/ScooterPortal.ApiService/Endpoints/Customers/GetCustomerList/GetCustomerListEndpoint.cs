namespace ScooterPortal.ApiService.Endpoints.Customers.GetCustomerList;

public class GetCustomerListEndpoint : EndpointWithoutRequest<List<CustomerDto>>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Get("customers");
    }

    public override Task<List<CustomerDto>> ExecuteAsync(CancellationToken ct) =>
        DbContext.Customers.Select(x => new CustomerDto
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName
        }).ToListAsync(ct);
}