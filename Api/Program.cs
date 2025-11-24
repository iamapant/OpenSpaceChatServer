
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Api.DAL;
using Api.Database;
using Api.IntraServer.GRpc;
using Api.Providers.Token;
using Api.Secrets;
using Microsoft.IdentityModel.Tokens;

namespace Api
{
    public class Program
    {
        public static async Task Main(string[] args) {
            var secretProvider = new SecretProvider();
            await secretProvider.Initialize();
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddLogging(o => {
                o.AddConsole();
                o.AddDebug();
            });
            builder.Services.AddDbContext<AppDbContext>();
            #region jwt
            var handler = new JwtSecurityTokenHandler() {
                //TODO: implementation
            };
            builder.Services.AddSingleton(handler);

            var tvp = new TokenValidationParameters() {
                //TODO: implementation
            };
            builder.Services.AddSingleton(tvp);
            #endregion
            builder.Services.AddScoped<IGlobalSettings, GlobalSettings>();
            
            builder.Services.AddScoped<JwtTokenProvider>();
            builder.Services.AddScoped<RefreshTokenProvider>();
            
            builder.Services.AddRepositories();
            
            builder.Services.AddGrpc();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapGrpcService<RegionalAuthValidation>();
            app.MapControllers();

            app.Run();
        }
    }
    
    public static class ProgramExtensions {
            public static IServiceCollection AddRepositories(this IServiceCollection services) {
                var repos = GetRepos();
                foreach (var repo in repos) services.AddScoped(repo);

                IEnumerable<Type> GetRepos() {
                    var assembly = typeof(DatabaseRepository).Assembly;
                    //Get all repository types
                    var types = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(DatabaseRepository)) && t.Name.EndsWith("Repository"));
                    //Get only concrete types
                    types = types.Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericTypeDefinition);
                    
                    return types;
                }
                return services;
            }
    }
}
