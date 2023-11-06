using DemoCorsoBlazor.Core.Weather;

namespace DemoBlazorServer.Services;

public class WeatherForecastServiceOnServer : IWeatherForecast
{
    private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };


    public Task<WeatherForecast[]?> GetForecast()
    {
        var data = Enumerable.Range(1, 50000).Select(index => new WeatherForecast
        {
            Date = DateTime.Today.AddDays(1),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();

        return Task.FromResult(data ?? null);

    }
}
