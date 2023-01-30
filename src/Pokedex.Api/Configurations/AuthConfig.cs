using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Pokedex.Business.Core.Auth;
using System.Text;

namespace Pokedex.Api.Configurations;

public static class AuthConfig
{
    public static IServiceCollection AddAuthenticationConfig(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var authSection = configuration.GetSection("AuthSettings");
        var settings = configuration.GetSection("AuthSettings").Get<AuthSettings>();

        services.Configure<AuthSettings>(authSection);
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings!.Secret)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = settings!.ValidIn,
                ValidIssuer = settings!.Issuer
            };
        });

        return services;
    }
}
