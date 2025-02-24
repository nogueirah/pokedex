using Microsoft.EntityFrameworkCore;
using PokeDomain.Interfaces;
using PokeDomain.Models;
using PokeInfrastructure.Data;

namespace PokeInfrastructure.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokeDbContext _context;

    public PokemonRepository(PokeDbContext context)
    {
        _context = context;
    }

    public async Task UpsertPokemonAsync(Pokemon pokemon)
    {
        var existing = await _context.Pokemons
            .Include(p => p.Types)
            .FirstOrDefaultAsync(p => p.Id == pokemon.Id);

        if (existing == null)
        {
            _context.Pokemons.Add(pokemon);
        }
        else
        {
            _context.Entry(existing).CurrentValues.SetValues(pokemon);
            existing.Types = pokemon.Types;
        }

        await _context.SaveChangesWithIdentityInsert<Pokemon>();
    }

    public async Task<List<Pokemon>> GetPokemonsAsync()
    {
        return await _context.Pokemons
            .Include(p => p.Types)
            .ToListAsync();
    }
}