using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokeDomain.Interfaces;
using PokeInfrastructure.Clients;
using PokeInfrastructure.Data;
using PokeInfrastructure.Repositories;

namespace PokeInfrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PokeDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PokeConnection")));

        services.AddScoped<IPokemonRepository, PokemonRepository>();
        services.AddHttpClient<IPokeApiClient, PokeApiClient>();

        return services;
    }
}