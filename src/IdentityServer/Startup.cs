using IdentityServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var builder = services.AddIdentityServer()
        .AddDeveloperSigningCredential()        //This is for dev only scenarios when you don’t have a certificate to use.
        .AddInMemoryApiScopes(Config.ApiScopes)
        .AddInMemoryClients(Config.Clients);
        
        services.AddHealthChecks();

        // omitted for brevity
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}