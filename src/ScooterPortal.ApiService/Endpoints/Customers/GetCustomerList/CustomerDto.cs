namespace ScooterPortal.ApiService.Endpoints.Customers.GetCustomerList;

public record CustomerDto
{
    public required int Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}