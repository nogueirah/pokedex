using PokeDomain.Models;

namespace PokeDomain.Interfaces;

public interface IPokemonRepository
{
    Task UpsertPokemonAsync(Pokemon pokemon);
    Task<List<Pokemon>> GetPokemonsAsync();
}