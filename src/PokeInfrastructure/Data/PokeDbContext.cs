using Microsoft.EntityFrameworkCore;
using PokeDomain.Models;

namespace PokeInfrastructure.Data;

public class PokeDbContext : DbContext
{
    public PokeDbContext(DbContextOptions<PokeDbContext> options) : base(options) { }

    public DbSet<Pokemon> Pokemons => Set<Pokemon>();
    public DbSet<PokemonType> PokemonTypes => Set<PokemonType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pokemon>()
            .HasMany(p => p.Types)
            .WithMany(t => t.Pokemons)
            .UsingEntity(j => j.ToTable("PokemonTypeMaps"));
    }
}