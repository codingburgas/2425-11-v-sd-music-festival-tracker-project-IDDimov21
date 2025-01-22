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

            ClaimsIdentity identity;
            if (!string.IsNullOrEmpty(email))
            {
                identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "auth");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        public async Task Login(string email)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "userEmail", email);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Logout()
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "userEmail");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}