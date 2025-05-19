using SzkolenieTechniczne2.Cinema.Domain.Entities;

namespace SzkolenieTechniczne2.Cinema.Common.Repositories;

public interface IMoviesRepository
{
    Task<Movie> GetByIdAsync(long id);

    Task<IEnumerable<Movie>> GetAllAsync();

    Task<IEnumerable<MovieCategory>> GetMovieCategoriesAsync();

    Task<bool> IsMovieExistAsync(string name, int year);

    Task<bool> IsSeanceExistAsync(DateTime seanceDate);

    Task AddAsync(Movie movie);

    Task UpdateAsync(Movie movie);

    Task<Movie> GetSeanceDetailsAsync(long movieId);

    Task<List<Seance>> GetSeancesByMovieIdAsync(long movieId);

    Task RemoveAsync(Movie movie);
}