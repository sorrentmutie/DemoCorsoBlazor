using DemoCorsoBlazor.Core.Weather;
using System.Net.Http.Json;

namespace DemoWASM.Services;

public class WeatherForecastWASMService : IWeatherForecast
{
    private readonly HttpClient http;

    public WeatherForecastWASMService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<WeatherForecast[]?> GetForecast()
    {
        return await http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }
}
