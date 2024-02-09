using CSLGaming.UI;
using CSLGaming.UI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Data.Common;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); // Denna services skapar ett ny instans vid varje anrop
builder.Services.AddSingleton<UIService>(); // Denna skapas sålänge programmet lever (är på)
builder.Services.AddHttpClient<CategoryHttpClient>();

await builder.Build().RunAsync();
