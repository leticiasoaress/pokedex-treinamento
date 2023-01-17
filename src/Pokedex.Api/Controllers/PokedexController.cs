using Microsoft.AspNetCore.Mvc;
using Pokedex.Business.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Pokedex.Api.Controllers;

[Route("pokedex")]
public class PokedexController : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Cadastrar pokémon.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddPokemon()
    {
        return Ok();
    }

    [HttpPut]
    [SwaggerOperation("Alterar cadastro de pokémon.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePokemon()
    {
        return NoContent();
    }

    [HttpDelete]
    [SwaggerOperation("Remover pokémon.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePokemon()
    {
        return NoContent();
    }

    [HttpGet("{pokemonId:guid}")]
    [SwaggerOperation("Obter pokémon por id.")]
    [ProducesResponseType(typeof(Pokemon), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPokemonById(Guid pokemonId)
    {
        return Ok();
    }

    [HttpGet("find")]
    [SwaggerOperation("Listar pokémons.")]
    [ProducesResponseType(typeof(IEnumerable<Pokemon>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FindPokemon()
    {
        return Ok();
    }
}
