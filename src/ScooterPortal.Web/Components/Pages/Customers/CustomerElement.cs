namespace ScooterPortal.Web.Components.Pages.Customers;

public record CustomerElement
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public bool Saved { get; set; } = true;
}