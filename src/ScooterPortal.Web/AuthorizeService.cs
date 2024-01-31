using Blazored.LocalStorage;
using Flurl.Http;
using Microsoft.AspNetCore.Components;

namespace ScooterPortal.Web;

public class AuthorizeService
{
    private readonly ILocalStorageService _localStorage;
    private readonly NavigationManager _navManager;

    public AuthorizeService(ILocalStorageService localStorage, NavigationManager navManager)
    {
        _localStorage = localStorage;
        _navManager = navManager;
    }

    public async Task<bool> IsLoggedIn()
    {
        var token = await GetToken();
        return !string.IsNullOrEmpty(token);
    }

    public async Task<bool> Login(HttpClient client, string username, string password)
    {
        using var flurlClient = new FlurlClient(client);
        var response = await flurlClient.Request("/login")
            .AllowHttpStatus(StatusCodes.Status401Unauthorized)
            .PostJsonAsync(new { username, password });

        if (response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            return false;
        }

        var token = await response.GetJsonAsync<TokenResponse>();
        await SetToken(token.Token);

        return true;
    }

    public async Task AddAuthorizationHeaderOrRedirect(FlurlCall call)
    {
        var token = await GetToken();
        if (token is null)
        {
            _navManager.NavigateTo("/login");
            return;
        }

        call.Request.WithOAuthBearerToken(token);
    }

    public void CheckIfUnauthorized(FlurlCall call)
    {
        if (call.Response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            _navManager.NavigateTo("/login");
        }
    }

    private async Task<string?> GetToken() => await _localStorage.GetItemAsync<string>("token");

    private async Task SetToken(string token)
    {
        await _localStorage.SetItemAsync("token", token);
    }

    public class TokenResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}