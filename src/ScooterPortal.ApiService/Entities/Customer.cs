namespace ScooterPortal.ApiService.Entities;

public class Customer : User
{
    public virtual List<Rental> Rentals { get; set; } = [];
}