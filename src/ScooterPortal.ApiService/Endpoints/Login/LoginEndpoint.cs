using System.Security.Claims;

namespace ScooterPortal.ApiService.Endpoints.Login;

public class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    public DatabaseContext DbContext { get; set; } = null!;

    public override void Configure()
    {
        Post("login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var admin = DbContext.Administrators
            .FirstOrDefault(x => string.Equals(x.Username.ToLower(), req.Username.ToLower()));

        if (admin is null || !BCrypt.Net.BCrypt.Verify(req.Password, admin.Password))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        var token = JWTBearer.CreateToken(
            signingKey: Config["JwtKey"]!,
            expireAt: DateTime.UtcNow.AddDays(1),
            claims: new[]
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Name, admin.Username),
                new Claim(ClaimTypes.GivenName, admin.FirstName),
                new Claim(ClaimTypes.Surname, admin.LastName)
            });

        await SendOkAsync(new()
        {
            Token = token
        }, ct);
    }
}