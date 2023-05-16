using Blazored.LocalStorage;
using KpiSchedule.Common.ServiceCollectionExtensions;
using KpiSchedule.Frontend;
using KpiSchedule.Frontend.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient(nameof(KpiScheduleApiClient), client => {
    var options = builder.Configuration.GetSection("KpiScheduleApiClient").Get<KpiScheduleApiClientOptions>();
    client.BaseAddress = new Uri(options.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
});
builder.Services.AddSerilogConsoleLogger();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<KpiScheduleApiClient>();

await builder.Build().RunAsync();
