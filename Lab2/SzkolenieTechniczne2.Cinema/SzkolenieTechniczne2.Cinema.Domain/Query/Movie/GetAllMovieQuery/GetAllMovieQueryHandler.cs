using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Update;
using SzkolenieTechniczne2.Cinema.Domain.Command;
using SzkolenieTechniczne2.Cinema.Domain.Query.DTOS;
using SzkolenieTechniczne2.Cinema.Domain.Repository;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetAllMovieQuery
{
   
internal sealed class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQuery, List<MovieDto>>
    {
        private readonly IMoviesRepository _moviesRepository;

        public GetAllMovieQueryHandler(IMoviesRepository repository)
        {
            _moviesRepository = repository;

        }

        public async Task<List<MovieDto>> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
        {

            var movies = await _moviesRepository.GetAllAsync();
            return movies.Select(movie => new MovieDto(movie.Id, movie.Name)).ToList();
        }
    }
}
