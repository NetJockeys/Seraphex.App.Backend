using MediatR;
using Seraphex.App.Application.EndpointRegistration;

namespace Seraphex.App.Application.Features.Weather.GetWeather;

public class GetWeatherEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/weather")
            .WithTags("Weather");

        group.MapGet("", () =>
            {
                string[] summaries =
                [
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                ];
                
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherViewModel
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetForecast")
            .Produces<List<WeatherViewModel>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);
    }
}