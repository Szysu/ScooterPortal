namespace ScooterPortal.ApiService.Endpoints.Customers.CreateCustomer;

public record CreateCustomerRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}