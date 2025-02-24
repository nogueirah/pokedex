using System.Net.Http.Json;
using PokeDomain.Models;

namespace PokeInfrastructure.Clients;

public interface IPokeApiClient
{
    Task<Pokemon> GetPokemonAsync(int id);
}

public class PokeApiClient : IPokeApiClient
{
    private readonly HttpClient _httpClient;

    public PokeApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
    }

    public async Task<Pokemon> GetPokemonAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<PokeApiResponse>($"pokemon/{id}");
        return new Pokemon
        {
            Id = id,
            Name = response.Name,
            Height = response.Height,
            Weight = response.Weight,
            Types = response.Types.Select(t => new PokemonType { Name = t.Type.Name }).ToList()
        };
    }

    private record PokeApiResponse(
        string Name,
        int Height,
        int Weight,
        List<TypeEntry> Types);

    private record TypeEntry(TypeInfo Type);
    private record TypeInfo(string Name);
}