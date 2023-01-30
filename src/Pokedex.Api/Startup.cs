using Pokedex.Api.Configurations;
using Pokedex.Api.Middlewares;
using Pokedex.Business.Core.Notifications;

namespace Pokedex.Api;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IServiceCollection _services;

    public Startup(WebApplicationBuilder builder)
    {
        _configuration = builder.Configuration;
        _services = builder.Services;
    }

    public void ConfigureServices()
    {
        _services.AddAuthenticationConfig(_configuration);
        _services.AddControllers();
        _services.AddEndpointsApiExplorer();
        _services.AddSwaggerGen(options => options.EnableAnnotations());
        _services.AddSmartNotification();
        _services.RegisterDI();
        _services.AddDbContexts(_configuration);
        _services.AddAutoMapper(GetType().Assembly);
    }

    public void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(options => options.MapControllers());
    }
}
