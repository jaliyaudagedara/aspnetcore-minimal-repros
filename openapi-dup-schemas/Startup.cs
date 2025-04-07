namespace WebApplication1;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSwaggerUI(x =>
        {
            x.SwaggerEndpoint("/openapi/v1.json", "My API");
        });

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapOpenApi();

            endpoints.MapControllers();
        });
    }
}