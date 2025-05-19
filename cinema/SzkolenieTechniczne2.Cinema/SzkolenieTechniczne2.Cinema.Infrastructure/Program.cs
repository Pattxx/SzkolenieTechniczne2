
using SzkolenieTechniczne2.Cinema.Domain.Entities;
using SzkolenieTechniczne2.Cinema.Domain.Repository;
using SzkolenieTechniczne2.Cinema.Infrastructure.Repository;
using SzkolenieTechniczne2.Infrastructure;


        Console.WriteLine("Hello, World!");
        using (var context = new CinemaTicketDbContext(
        new Microsoft.EntityFrameworkCore.DbContextOptions<CinemaTicketDbContext>()))
        {
            IMoviesRepository _moviesRepository = new MovieRepository(context);
            await _moviesRepository.AddAsync(new Movie("Matrix", 2000, 120, 2));
            await _moviesRepository.AddAsync(new Movie("Krzyżacy", 1961, 180, 2));
            IEnumerable<Movie> movieList = (IEnumerable<Movie>)_moviesRepository.GetAllAsync();
            foreach (Movie movie in movieList)
                Console.WriteLine(movie.Name);
        }
