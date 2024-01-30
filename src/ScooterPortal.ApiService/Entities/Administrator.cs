namespace ScooterPortal.ApiService.Entities;

public class Administrator : User
{
    public required string Username { get; set; }
    public required string Password { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}