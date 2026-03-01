namespace Seraphex.App.Application.Features.Weather.GetWeather;

record WeatherViewModel(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}