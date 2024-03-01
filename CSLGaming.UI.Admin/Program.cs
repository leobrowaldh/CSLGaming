using CSLGaming.UI.Admin;
using CSLGaming.UI.Admin.AdminServices;
using CSLGaming.UI.Http.Clients;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<UIAdminService>();
builder.Services.AddHttpClient<AdminCategoryClient>();
await builder.Build().RunAsync();
