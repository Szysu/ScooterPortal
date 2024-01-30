namespace ScooterPortal.ApiService.Endpoints.Scooters.DeleteScooter;

public class DeleteScooterEndpoint : EndpointWithoutRequest
{
    public DatabaseContext DbContext { get; set; }

    public override void Configure()
    {
        Delete("scooters/{id}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var scooterId = Route<int>("id");
        var scooter = DbContext.Scooters.FirstOrDefault(x => x.Id == scooterId);

        if (scooter is null)
        {
            return SendNotFoundAsync(ct);
        }

        DbContext.Scooters.Remove(scooter);
        DbContext.SaveChanges();

        return SendNoContentAsync(ct);
    }
}