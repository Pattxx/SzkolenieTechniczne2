
using MediatR;
using SzkolenieTechniczne2.Cinema.Common.Repositories;
using SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Create;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Update
{
    class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Result>
    {
        private readonly IMoviesRepository _repository;

        public UpdateMovieCommandHandler(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMovieCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var movie = await _repository.GetByIdAsync(request.Id);
            if (movie == null)
            {
                return Result.Fail("Movie not found.");
            }

            movie.SetName(request.Name);
            movie.SetYear(request.Year);
            movie.SetSeanceTime(request.SeanceTime);

            await _repository.UpdateAsync(movie);

            return Result.Ok();
        }
    }
}
