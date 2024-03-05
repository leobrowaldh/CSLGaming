using CSLGaming.UI.Admin;
using CSLGaming.UI.Admin.Services;
using CSLGaming.UI.Http.Clients;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<AdminCategoryService>();
builder.Services.AddHttpClient<AdminCategoryHttpClient>();
await builder.Build().RunAsync();