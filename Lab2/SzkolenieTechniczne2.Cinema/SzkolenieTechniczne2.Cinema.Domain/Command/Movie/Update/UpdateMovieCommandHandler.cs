using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Create;
using SzkolenieTechniczne2.Cinema.Domain.Repository;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Update
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Result>
    {
        private readonly IMoviesRepository _moviesRepository;
        public UpdateMovieCommandHandler(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<Result> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMovieCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }
            var movie = await _moviesRepository.GetByIdAsync(request.movieId);

            if (movie == null)
            {
                return Result.Fail("Nie ma takiego filmu.");
            }

            //aktualizacja pol
            movie.SetName(request.Name);
            movie.SetYear(request.Year);
            movie.SetSeanceTime(request.SeanceTime);

            await _moviesRepository.UpdateAsync(movie);
            return Result.Ok();
        }
    }
}
