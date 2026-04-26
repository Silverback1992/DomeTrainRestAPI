using Movies.Application.Models;
using Movies.Application.Repositories.Interfaces;

namespace Movies.Application.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly List<Movie> _movies = [];

    public Task<bool> CreateAsync(Movie movie)
    {
        _movies.Add(movie);
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        int removedCount = _movies.RemoveAll(x => x.Id == id);
        bool movieDeleted = removedCount > 0;

        return Task.FromResult(movieDeleted);
    }

    public Task<IEnumerable<Movie>> GetAllAsync()
    {
        return Task.FromResult(_movies.AsEnumerable());
    }

    public Task<Movie?> GetByIdAsync(Guid id)
    {
        var movie = _movies.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(movie);
    }

    public Task<Movie?> GetBySlugAsync(string slug)
    {
        var movie = _movies.SingleOrDefault(x => x.Slug == slug);
        return Task.FromResult(movie);
    }

    public Task<bool> UpdateAsync(Movie movie)
    {
        int movieIdx = _movies.FindIndex(x => x.Id == movie.Id);

        if (movieIdx == -1)
        {
            return Task.FromResult(false);
        }

        _movies[movieIdx] = movie;

        return Task.FromResult(true);
    }
}
