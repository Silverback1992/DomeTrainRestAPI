using Dapper;
using Movies.Application.Database.Interfaces;

namespace Movies.Application.Database;

public class DbInitializer
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    public DbInitializer(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    public async Task InitializeAsync()
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        await connection.ExecuteAsync("""
            create table if not exists movies (
                id UUID primary key,
                slug TEXT not null,
                title TEXT not null,
                yearOfRelease INT not null);
        """);

        await connection.ExecuteAsync("""
            create unique index concurrently if not exists movies_slug_uindex 
            on movies
            using btree(slug);
        """);

        await connection.ExecuteAsync("""
            create table if not exists genres (
            movieId UUID references movies (Id),
            name TEXT not null);
        """);
    }
}
