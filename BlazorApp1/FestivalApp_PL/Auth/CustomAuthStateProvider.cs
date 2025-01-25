using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FestivalApp_PL.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;

        public CustomAuthStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var email = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "userEmail");
            var name = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "userName");

            ClaimsIdentity identity;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(name))
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email)
                }, "auth");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        public async Task Login(string email, string name)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "userEmail", email);
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "userName", name);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Logout()
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "userEmail");
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "userName");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}