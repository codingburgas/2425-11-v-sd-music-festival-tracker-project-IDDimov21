using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_currentUser));
    }

    public void Login(string email)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, email)
        }, "auth");

        _currentUser = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }

    public void Logout()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }
}