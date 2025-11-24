using Api.Grpc;
using Api.Secrets;
using Regional.Database;
using Regional.Services;
using ZiggyCreatures.Caching.Fusion;

namespace Regional;

public class Program {
    public static async Task Main(string[] args) {
        var secretProvider = new SecretProvider();
        await secretProvider.Initialize();
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddFusionCache().TryWithAutoSetup();
        builder.Services.AddAuthorization();
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("RemoteJwtPolicy", policy =>
                policy.Requirements.Add(new RemoteJwtRequirement()));
        });
        builder.Services.AddGrpcClient<AuthValidationService.AuthValidationServiceClient>(o => {
            o.Address = new Uri(builder.Configuration["MainServerConnection:Url"] ?? throw new InvalidOperationException());
        });
        builder.Services.AddDbContext<RegionalDbContext>();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment()) { app.MapOpenApi(); }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        var summaries = new[] {
            "Freezing"
          , "Bracing"
          , "Chilly"
          , "Cool"
          , "Mild"
          , "Warm"
          , "Balmy"
          , "Hot"
          , "Sweltering"
          , "Scorching"
        };

        app.MapGet("/weatherforecast"
             , (HttpContext httpContext) => {
                   var forecast = Enumerable.Range(1, 5)
                                            .Select(index => new WeatherForecast {
                                                Date = DateOnly.FromDateTime(
                                                    DateTime.Now.AddDays(index))
                                              , TemperatureC = Random.Shared.Next(-20, 55)
                                              , Summary = summaries[
                                                    Random.Shared.Next(summaries.Length)]
                                            })
                                            .ToArray();
                   return forecast;
               })
           .WithName("GetWeatherForecast");

        app.Run();
    }
}