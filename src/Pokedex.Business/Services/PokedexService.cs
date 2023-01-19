using Pokedex.Business.Entities;
using Pokedex.Business.Repositories;

namespace Pokedex.Business.Services;

public class PokedexService : IPokedexService
{
    private readonly IPokemonRepository _pokemonRepository;

    public PokedexService(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    public async Task<Guid?> AddPokemonAsync(Pokemon pokemon)
    {
        var validation = pokemon.Validate();
        if (!validation.IsValid)
        {
            // Notificar erro para usuario 
            return null;
        }

        var registredPokemon = await _pokemonRepository.GetByNameAsync(pokemon.Name);
        if (registredPokemon != null)
        {
            // Notificar erro para usuario 
            return null;
        }

        await _pokemonRepository.AddAsync(pokemon);
        // Comitar a operação

        return pokemon.Id;
    }

    public Task DeletePokemonAsync(Guid pokemonId)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePokemonAsync(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }
}
