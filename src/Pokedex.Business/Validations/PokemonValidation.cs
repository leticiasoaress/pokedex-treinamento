using FluentValidation;
using Pokedex.Business.Entities;

namespace Pokedex.Business.Validations;

public class PokemonValidation : AbstractValidator<Pokemon>
{
    public PokemonValidation()
    {
        RuleFor(p => p.Name)
            .Length(3, 50)
            .WithMessage("O Nome do pokémon deve ter entre {MinLength} e {MaxLength} caracteres.");

        RuleFor(p => p.CategoryId)
            .NotEmpty()
            .WithMessage("É necessário informar uma Categoria válida.");

        RuleFor(p => p.Hp)
            .GreaterThan(0)
            .WithMessage("O HP deve ser maior que zero.");

        RuleFor(p => p.Attack)
            .GreaterThan(0)
            .WithMessage("O Ataque deve ser maior que zero.");

        RuleFor(p => p.Defense)
            .GreaterThan(0)
            .WithMessage("A Defesa deve ser maior que zero.");

        RuleFor(p => p.Speed)
            .GreaterThan(0)
            .WithMessage("A Velocidade deve ser maior que zero.");
    }
}
