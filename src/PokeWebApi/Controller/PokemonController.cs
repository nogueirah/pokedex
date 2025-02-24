using Microsoft.AspNetCore.Mvc;
using PokeApplication.Interfaces;
using PokeWebApi.Models;

namespace PokeWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokeDataService _pokeDataService;

    public PokemonController(IPokeDataService pokeDataService)
    {
        _pokeDataService = pokeDataService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PokemonDto>>> GetPokemons()
    {
        var pokemons = await _pokeDataService.GetPokemonsAsync();
        var dtos = pokemons.Select(p => new PokemonDto
        {
            Id = p.Id,
            Name = p.Name,
            Height = p.Height,
            Weight = p.Weight,
            Types = p.Types.Select(t => t.Name).ToList()
        });

        return Ok(dtos);
    }
}