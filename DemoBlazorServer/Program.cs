using DemoBlazorServer.Data;
using DemoBlazorServer.Services;
using DemoCorsoBlazor.Core.GestioneEventi;
using DemoCorsoBlazor.Core.MyMap;
using DemoCorsoBlazor.Core.RandomUser;
using DemoCorsoBlazor.Core.ReqRes;
using DemoCorsoBlazor.Core.Weather;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IGestioneEventi, ServizioEventiServer>();
builder.Services.AddScoped<IWeatherForecast, WeatherForecastServiceOnServer>();
builder.Services.AddDbContext<EventiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IReqResData, ReqResService>();
builder.Services.AddScoped<IMyMap, ServizioMappaServer>();

builder.Services.AddScoped<IRandomUsers, RandomUserService>();
builder.Services.AddHttpClient("reqres", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://reqres.in/api/users");
});
builder.Services.AddHttpClient("httpuser", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://randomuser.me/api");
});

builder.Services.AddScoped<HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
