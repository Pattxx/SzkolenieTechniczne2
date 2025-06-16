using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Common.Repositories;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;
using SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetAllMoviesQuery;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Seances.GetSeanceDetails
{
    class GetSeanceQueryHanlder : IRequestHandler<GetSeanceQuery, MovieSeanceDetailsDto>
    {
        private readonly IMoviesRepository _repository;

        public GetSeanceQueryHanlder(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieSeanceDetailsDto> Handle(GetSeanceQuery query, CancellationToken cancellationToken)
        {
            var movie = await _repository.GetSeanceDetailsAsync(query.MovieId);
            if (movie == null)
            {
                throw new NullReferenceException("Given movie does not exist.");
            }

            var seance = movie.Seances.SingleOrDefault(x => x.Id == query.SeanceId);
            if (seance == null)
            {
                throw new NullReferenceException("Given seance does not exist.");
            }

            return new MovieSeanceDetailsDto(movie.Id, seance.Id, movie.Name, seance.Date);
        }
    }
}

