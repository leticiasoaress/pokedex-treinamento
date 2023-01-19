using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Api.Models;
using Pokedex.Business.Entities;
using Pokedex.Business.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Pokedex.Api.Controllers;

[Route("pokedex")]
public class PokedexController : ControllerBase
{
    private readonly IPokedexService _pokedexService;
    private readonly IMapper _mapper;

    public PokedexController(
        IPokedexService pokedexService,
        IMapper mapper)
    {
        _pokedexService = pokedexService;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerOperation("Cadastrar pokémon.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddPokemon([FromBody] PokemonModel model)
    {
        var pokemon = _mapper.Map<Pokemon>(model);
        var pokemonId = await _pokedexService.AddPokemonAsync(pokemon);

        return Created(
            $"{HttpContext.Request.Path}/{pokemonId}",
            null);
    }

    [HttpPut]
    [SwaggerOperation("Alterar cadastro de pokémon.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePokemon([FromBody] PokemonModel model)
    {
        var pokemon = _mapper.Map<Pokemon>(model);
        await _pokedexService.UpdatePokemonAsync(pokemon);
        
        return NoContent();
    }

    [HttpDelete("{pokemonId:guid}")]
    [SwaggerOperation("Remover pokémon.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePokemon(Guid pokemonId)
    {
        await _pokedexService.DeletePokemonAsync(pokemonId);

        return NoContent();
    }

    [HttpGet("{pokemonId:guid}")]
    [SwaggerOperation("Obter pokémon por id.")]
    [ProducesResponseType(typeof(PokemonModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPokemonById(Guid pokemonId)
    {
        return Ok();
    }

    [HttpGet("find")]
    [SwaggerOperation("Listar pokémons.")]
    [ProducesResponseType(typeof(IEnumerable<PokemonModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FindPokemon()
    {
        return Ok();
    }
}
