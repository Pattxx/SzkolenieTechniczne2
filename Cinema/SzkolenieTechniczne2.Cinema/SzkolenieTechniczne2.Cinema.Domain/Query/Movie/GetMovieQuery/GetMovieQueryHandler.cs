using MediatR;
using SzkolenieTechniczne2.Cinema.Common.Repositories;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieQuery
{
   public sealed class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDetailsDto>
    {
        private readonly IMoviesRepository _repository;

        public GetMovieQueryHandler(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieDetailsDto> Handle(GetMovieQuery query, CancellationToken cancellationToken)
        {
            var movie = await _repository.GetByIdAsync(query.MovieId);

            if (movie == null)
            {
                throw new NullReferenceException("Given movie does not exist.");
            }

            var seances = movie.Seances?
                .Select(seance => new SeanceDto(seance.Id, seance.Date))
                .ToList() ?? new List<SeanceDto>();

            return new MovieDetailsDto(
                movie.Id,
                movie.Name,
                movie.Year,
                movie.SeanceTime,
                seances
            );
        }
    }
}
