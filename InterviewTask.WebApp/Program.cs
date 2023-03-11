using InterviewTask.WebApp;
using InterviewTask.WebApp.Clients;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

var baseAddress = builder.Configuration["BaseAddress"];
if (string.IsNullOrEmpty(baseAddress))
{
    throw new InvalidOperationException("Base address is missing from appsettings file.");
}

builder.Services.AddScoped(s => new HttpClient());

builder.Services.AddHttpClient<AppHttpClient>(client =>
    client.BaseAddress = new Uri(baseAddress));

await builder.Build().RunAsync();
