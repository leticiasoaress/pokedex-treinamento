using Pokedex.Business.Entities;
using Pokedex.Business.Queries;

namespace Pokedex.Business.Services;

public interface IPokedexService
{
    Task<Guid?> AddPokemonAsync(Pokemon pokemon);
    Task UpdatePokemonAsync(Pokemon pokemon);
    Task DeletePokemonAsync(Guid pokemonId);
}
