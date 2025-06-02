
using MediatR;
using SzkolenieTechniczne2.Cinema.Common.Repositories;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieCategories
{
    internal sealed class GetMovieCategoriesQueryHandler : IRequestHandler<GetMovieCategoriesQuery, List<MovieCategoryDto>>
    {
        private readonly IMoviesRepository _repository;

        public GetMovieCategoriesQueryHandler(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MovieCategoryDto>> Handle(GetMovieCategoriesQuery query, CancellationToken cancellationToken)
        {
            var movies = await _repository.GetMovieCategoriesAsync();

            return movies
                .Select(movie => new MovieCategoryDto(movie.Id, movie.Name))
                .ToList();
        }
    }
}
