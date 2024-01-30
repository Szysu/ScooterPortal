namespace ScooterPortal.ApiService.Entities;

public abstract class User : Entity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}