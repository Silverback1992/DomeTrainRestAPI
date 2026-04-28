using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Database;
using Movies.Application.Database.Interfaces;
using Movies.Application.Repositories;
using Movies.Application.Repositories.Interfaces;
using Movies.Application.Services;
using Movies.Application.Services.Interfaces;

namespace Movies.Application.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMovieRepository, MovieRepository>();
        services.AddSingleton<IMovieService, MovieService>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IDbConnectionFactory>(_ => new NpgsqlConnectionFactory(connectionString));
        services.AddSingleton<DbInitializer>();
        return services;
    }
}
