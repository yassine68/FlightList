using FlightList.Client.BlazorWA;
using FlightList.Client.BlazorWA.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IAirportService, AirportService>();

builder.Configuration.AddJsonFile("appsettings.json", true);

builder.Services.AddSingleton<ApiSettings>();

await builder.Build().RunAsync();
