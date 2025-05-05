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

        public async Task<Movie> GetByIdAsync(long id)
        {
            return await _context.Movies
                .Include(c => c.Seances)
                    .ThenInclude(s => s.Tickets)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<bool> IsMovieExistAsync(string name, int year)
        {
            return await _context.Movies
                .AnyAsync(x => x.Name == name && x.Year == year);
        }

        public async Task<bool> IsSeanceExistAsync(DateTime seanceDate)
        {
            return await _context.Seances
                .AnyAsync(x => x.Date == seanceDate);
        }

        public async Task<List<Seance>> GetSeancesByMovieIdAsync(long movieId)
        {
            return await _context.Seances
                .Where(x => x.MovieId == movieId)
                .ToListAsync();
        }

        public async Task RemoveAsync(Movie movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetSeanceDetailsAsync(long movieId)
        {
            return await _context.Movies
                .Where(x => x.Id == movieId)
                .Include(t => t.Seances)
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieCategory>> GetMovieCategoriesAsync()
        {
            return await _context.MovieCategories
                .ToListAsync();
        }

    }
}
