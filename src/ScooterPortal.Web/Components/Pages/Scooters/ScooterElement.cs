namespace ScooterPortal.Web.Components.Pages.Scooters;

public record ScooterElement
{
    public int Id { get; set; }
    public string Model { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public int BatteryLevel { get; set; }

    public bool Saved { get; set; } = true;
}