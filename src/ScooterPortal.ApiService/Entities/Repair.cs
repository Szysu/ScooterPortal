namespace ScooterPortal.ApiService.Entities;

public class Repair : Entity
{
    public required int ScooterId { get; set; }
    public required string Reason { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public virtual Scooter Scooter { get; set; } = null!;
}