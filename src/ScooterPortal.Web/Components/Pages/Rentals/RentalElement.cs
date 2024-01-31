namespace ScooterPortal.Web.Components.Pages.Rentals;

public record RentalElement
{
    public int Id { get; set; }
    public int ScooterId { get; set; }
    public int CustomerId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }

    public bool Saved { get; set; } = true;
}