using FluentValidation;
using MediatR;
using SzkolenieTechniczne2.Cinema.Common.Repositories;
using SzkolenieTechniczne2.Cinema.Domain.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Seances.Register
{
    internal class RegisterSeanceCommandHandler : IRequestHandler<RegisterSeanceCommand, Result>
    {
        private readonly IMoviesRepository _repository;

        public RegisterSeanceCommandHandler(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RegisterSeanceCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await new RegisterSeanceCommandValidator().ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            if (await _repository.IsSeanceExistAsync(command.SeanceDate))
            {
                return Result.Fail("This seance already exists.");
            }

            var movie = await _repository.GetByIdAsync(command.MovieId);
            if (movie == null)
            {
                return Result.Fail("This movie does not exist.");
            }

            var seance = new Seance(command.SeanceDate, command.MovieId);

            movie.Seances.Add(seance);

            await _repository.UpdateAsync(movie);

            return Result.Ok();
        }
    }
}
