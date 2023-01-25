using Pokedex.Business.Core;
using Pokedex.Business.Entities;
using Pokedex.Business.Queries;

namespace Pokedex.Business.Repositories;

public interface IPokemonRepository : IRepository
{
    Task AddAsync(Pokemon pokemon);
    void Update(Pokemon pokemon);
    void Delete(Guid pokemonId);

    Task<bool> HasPokemonAsync(Guid pokemonId);
    Task<Pokemon?> GetByIdAsync(Guid pokemonId);
    Task<Pokemon?> GetByNameAsync(string name);
    Task<IEnumerable<Pokemon>> FindAsync(FindPokemonQuery query);
}
