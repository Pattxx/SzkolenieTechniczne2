using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Repository
{
    public interface IMoviesRepository
    {
        Movie GetById(long id);
        IEnumerable<Movie> GetAll();
        IEnumerable<MovieCategory> GetMovieCategories();
        bool IsMovieExists(string name, int year);
        bool IsSeanceExists(DateTime seanceDate);
        void Add(Movie movie);
        void Update(Movie movie);
        Movie GetSeanceDetails(long moviedId);
        List<Seance> GetSeancesByMovieId(long movieId);
        void RemoveMovie(Movie movie);
    }
}
