using PokeApplication.Interfaces;

namespace PokeJobs.Jobs;

public class PokeDataUpsertJob
{
    private readonly IPokeDataService _pokeDataService;

    public PokeDataUpsertJob(IPokeDataService pokeDataService)
    {
        _pokeDataService = pokeDataService;
    }

    public async Task ExecuteAsync()
    {
        // Example: Process first 151 Pokémon
        for (int i = 1; i <= 151; i++)
        {
            await _pokeDataService.FetchAndUpsertPokemonDataAsync(i);
        }
    }
}