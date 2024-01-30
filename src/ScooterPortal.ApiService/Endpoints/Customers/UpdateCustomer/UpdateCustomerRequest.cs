namespace ScooterPortal.ApiService.Endpoints.Customers.UpdateCustomer;

public record UpdateCustomerRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}