using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PokeDomain.Models;
public class Pokemon
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<PokemonType> Types { get; set; } = new();
}

public class PokemonType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Pokemon> Pokemons { get; set; } = new();
}