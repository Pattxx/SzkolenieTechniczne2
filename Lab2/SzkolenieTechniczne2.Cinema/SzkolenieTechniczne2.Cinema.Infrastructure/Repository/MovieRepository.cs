using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Entities;
using SzkolenieTechniczne2.Cinema.Domain.Repository;
using SzkolenieTechniczne2.Infrastructure;

namespace SzkolenieTechniczne2.Cinema.Infrastructure.Repository
{
    public class MovieRepository : IMoviesRepository
    {
        private readonly CinemaTicketDbContext _context;
        public MovieRepository(CinemaTicketDbContext context) 
        {
            _context = context;
        }

        public Movie GetById(long id)
        {
            return _context.Movies
                .Include(m => m.Seances)
                .ThenInclude(s => s.Tickets)
                .SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<Movie> GetAll() 
        {
            return _context.Movies.ToList();
        }
        public bool IsMovieExists(string name, int year)
        {
            return _context.Movies.Any(x => x.Name == name && x.Year == year);
        }

        public bool IsSeanceExists(DateTime seanceDate)
        {
            return _context.Seances.Any(x => x.Date == seanceDate);
        }

        public List<Seance> GetSeancesByMovieId(long movieId)
        {
            return _context.Seances.Where(x => x.MovieId == movieId).ToList();
        }

        public Movie GetSeanceDetails(long movieId) 
        {
            return _context.Movies
                .Include(m => m.Seances)
                .SingleOrDefault(x => x.Id == movieId);
        }

        public IEnumerable<MovieCategory> GetMovieCategories()
        {
            return _context.MovieCategories.ToList();
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public void Update(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
        }

        public void RemoveMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
