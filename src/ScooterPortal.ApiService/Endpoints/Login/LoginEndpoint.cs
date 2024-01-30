namespace ScooterPortal.ApiService.Endpoints;

public class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    public DatabaseContext DbContext { get; set; } = null!;
    public JwtGenerator JwtGenerator { get; set; } = null!;

    public override void Configure()
    {
        Post("/api/login");
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

        await SendOkAsync(new()
        {
            Token = JwtGenerator.GenerateToken(admin)
        }, ct);
    }
}