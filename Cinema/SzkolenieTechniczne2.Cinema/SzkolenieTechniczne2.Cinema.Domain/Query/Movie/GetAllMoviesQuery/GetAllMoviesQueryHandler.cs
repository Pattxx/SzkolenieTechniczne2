
using MediatR;
using SzkolenieTechniczne2.Cinema.Common.Repositories;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetAllMoviesQuery
{
    internal sealed class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieDto>>
    {
        private readonly IMoviesRepository _repository;

        public GetAllMoviesQueryHandler(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MovieDto>> Handle(GetAllMoviesQuery query, CancellationToken cancellationToken)
        {
            var movies = await _repository.GetAllAsync();

            return movies
                .Select(movie => new MovieDto(movie.Id, movie.Name))
                .ToList();
        }
    }
}
