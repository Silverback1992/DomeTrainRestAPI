using Movies.Application.Models;

namespace Movies.Application.Services.Interfaces;

public interface IMovieService
{
    Task<bool> CreateAsync(Movie movie);
    Task<Movie?> GetByIdAsync(Guid id);
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie?> UpdateAsync(Movie movie);
    Task<bool> DeleteAsync(Guid id);
    Task<Movie?> GetBySlugAsync(string slug);
}
