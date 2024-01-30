namespace ScooterPortal.ApiService.Entities;

public class Rental : Entity
{
    public required int ScooterId { get; set; }
    public required int CustomerId { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public virtual Scooter Scooter { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
}