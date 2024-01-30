using ScooterPortal.ApiService.Services;

namespace ScooterPortal.ApiService.Endpoints.Scooters.EmergencyStopScooter;

public class EmergencyStopScooterEndpoint : EndpointWithoutRequest
{
    public DatabaseContext DbContext { get; set; } = null!;
    public ScooterCommandService ScooterCommands { get; set; } = null!;

    public override void Configure()
    {
        Post("scooters/{id}/emergency-stop");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var scooterId = Route<int>("id");
        var scooter = DbContext.Scooters.FirstOrDefault(x => x.Id == scooterId);

        if (scooter is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await ScooterCommands.EmergencyStop(scooterId);

        await SendOkAsync(ct);
    }
}