using MediatR;
using SzkolenieTechniczne2.Cinema.Common.Repositories;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Create
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Result>
    {
        private readonly IMoviesRepository _moviesRepository;

        public CreateMovieCommandHandler(IMoviesRepository repository)
        {
            _moviesRepository = repository;
        }

        public async Task<Result> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMovieCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            if (await _moviesRepository.IsMovieExistAsync(request.Name, request.Year))
            {
                return Result.Fail("This movie already exists.");
            }

            var movie = new SzkolenieTechniczne2.Cinema.Domain.Entities.Movie(
                request.Name,
                request.Year,
                request.SeanceTime,
                request.MovieCategoryId);

            await _moviesRepository.AddAsync(movie);


            return Result.Ok();
        }
    }
}
