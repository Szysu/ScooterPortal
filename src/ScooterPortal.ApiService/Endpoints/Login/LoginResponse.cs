namespace ScooterPortal.ApiService.Endpoints;

public record LoginResponse
{
    public required string Token { get; init; }
}