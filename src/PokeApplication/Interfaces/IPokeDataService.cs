using PokeDomain.Models;

namespace PokeApplication.Interfaces;

public interface IPokeDataService
{
    Task FetchAndUpsertPokemonDataAsync(int pokemonId);
    Task<List<Pokemon>> GetPokemonsAsync();
}