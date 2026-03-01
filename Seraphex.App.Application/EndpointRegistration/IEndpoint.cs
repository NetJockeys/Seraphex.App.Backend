namespace Seraphex.App.Application.EndpointRegistration;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}