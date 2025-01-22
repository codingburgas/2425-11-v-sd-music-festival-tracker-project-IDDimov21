using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using FestivalApp_PL;
using FestivalApp_PL.Auth;
using FestivalApp_BLL.Services;
using FestivalApp_DAL.Repository;
using FestivalApp_DAL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add Authentication Services
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

// Database Connection (Replace with your actual connection string)
var connectionString = "Server=tcp:sqldbserver.database.windows.net,1433;Initial Catalog=userdatabase;Persist Security Info=False;User ID=adminserv;Password=admpass1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

await builder.Build().RunAsync();