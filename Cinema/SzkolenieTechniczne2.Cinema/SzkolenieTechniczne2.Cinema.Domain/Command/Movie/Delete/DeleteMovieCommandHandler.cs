using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Common.Repositories;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Delete
{
    public sealed class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Result>
    {
        private readonly IMoviesRepository _repository;

        public DeleteMovieCommandHandler(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = await _repository.GetByIdAsync(command.Id);
            if (movie == null)
            {
                return Result.Fail("Movie does not exist.");
            }

            await _repository.RemoveAsync(movie);

            return Result.Ok();
        }
    }
}
