using Pokedex.Business.Repositories;
using Pokedex.Business.Services;
using Pokedex.Infra.Repositories;

namespace Pokedex.Api.Configurations;

public static class IoC
{
    public static IServiceCollection RegisterDI(this IServiceCollection services)
    {
        services.AddServices();
        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPokedexService, PokedexService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPokemonRepository, PokemonRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
