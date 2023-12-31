using DemoCorsoBlazor.Core.GestioneEventi;
using DemoCorsoBlazor.Core.MyMap;
using DemoCorsoBlazor.Core.RandomUser;
using DemoCorsoBlazor.Core.ReqRes;
using DemoCorsoBlazor.Core.Weather;
using DemoCorsoBlazor.Library;
using DemoWASM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Polly;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IGestioneEventi, ServizioEventi>();
builder.Services.AddScoped<IWeatherForecast, WeatherForecastWASMService>();
builder.Services.AddScoped<IReqResData, ReqResService>();
builder.Services.AddScoped<IMyMap, ServizioMappa>();
builder.Services.AddScoped<IRandomUsers, RandomUserService>();
builder.Services.AddHttpClient("reqres", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://reqres.in/api/users");
})
 .AddTransientHttpErrorPolicy(
    p => p.WaitAndRetryAsync(new[]
    {
        TimeSpan.FromSeconds(5),
        TimeSpan.FromSeconds(10),
        TimeSpan.FromSeconds(20)
    }));

builder.Services.AddHttpClient("httpuser", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://randomuser.me/api");
});


await builder.Build().RunAsync();
