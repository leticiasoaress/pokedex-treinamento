namespace Pokedex.Api;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IServiceCollection _services;

    public Startup(WebApplicationBuilder builder)
    {
        this._configuration = builder.Configuration;
        this._services = builder.Services;
    }

    public void ConfigureServices()
    {
        this._services.AddControllers();
        this._services.AddEndpointsApiExplorer();
        this._services.AddSwaggerGen();
    }

    public void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(options => options.MapControllers());
    }
}
