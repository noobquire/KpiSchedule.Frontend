using Blazored.LocalStorage;
using KpiSchedule.Frontend;
using KpiSchedule.Frontend.Client;
using KpiSchedule.Frontend.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient(nameof(KpiScheduleApiClient), client => {
    var options = builder.Configuration.GetSection("KpiScheduleApiClient").Get<KpiScheduleApiClientOptions>();
    client.BaseAddress = new Uri(options.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
});
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<KpiScheduleApiClient>();
builder.Services.AddSingleton<AppStateViewModel>();

await builder.Build().RunAsync();
