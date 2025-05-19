using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Repository;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Delete
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Result>
    {
        private readonly IMoviesRepository _moviesRepository;
        public DeleteMovieCommandHandler(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<Result> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteMovieCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }
            var movie = await _moviesRepository.GetByIdAsync(request.Id);

            if (movie == null)
            {
                return Result.Fail("Nie ma takiego filmu.");
            }
     
            await _moviesRepository.RemoveAsync(movie);
            return Result.Ok();
        }
    }
}
