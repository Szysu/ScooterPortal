namespace ScooterPortal.ApiService.Endpoints.Login;

public record LoginResponse
{
    public required string Token { get; init; }
}