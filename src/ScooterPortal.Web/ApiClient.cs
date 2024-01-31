using Flurl.Http;

namespace ScooterPortal.Web;

public class ApiClient : FlurlClient
{
    public ApiClient(AuthorizeService authService, HttpClient httpClient) : base(httpClient)
    {
        this.BeforeCall(authService.AddAuthorizationHeaderOrRedirect);
        this.AllowHttpStatus(StatusCodes.Status401Unauthorized);
        this.AfterCall(authService.CheckIfUnauthorized);
    }
}