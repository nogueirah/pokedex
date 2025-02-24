using PokeApplication.Interfaces;
using PokeDomain.Interfaces;
using PokeDomain.Models;
using PokeInfrastructure.Clients;

namespace PokeApplication.Services;

public class PokeDataService : IPokeDataService
{
    private readonly IPokemonRepository _pokemonRepo;
    private readonly IPokeApiClient _pokeApiClient;  

    public PokeDataService(
        IPokemonRepository pokemonRepo,
        IPokeApiClient pokeApiClient)
    {
        _pokemonRepo = pokemonRepo;
        _pokeApiClient = pokeApiClient;
    }

    public async Task<List<Pokemon>> GetPokemonsAsync()
    {
        return await _pokemonRepo.GetPokemonsAsync();
    }

    public async Task FetchAndUpsertPokemonDataAsync(int pokemonId)
    {
        var pokemonData = await _pokeApiClient.GetPokemonAsync(pokemonId);
        await _pokemonRepo.UpsertPokemonAsync(pokemonData);
    }
}