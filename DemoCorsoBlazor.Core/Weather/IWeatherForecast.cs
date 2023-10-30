namespace DemoCorsoBlazor.Core.Weather;

public interface IWeatherForecast
{
    Task<WeatherForecast[]?> GetForecast();
}
