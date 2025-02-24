using Microsoft.Extensions.DependencyInjection;
using PokeApplication.Interfaces;
using PokeApplication.Services;

namespace PokeApplication;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPokeDataService, PokeDataService>();
        return services;
    }
}