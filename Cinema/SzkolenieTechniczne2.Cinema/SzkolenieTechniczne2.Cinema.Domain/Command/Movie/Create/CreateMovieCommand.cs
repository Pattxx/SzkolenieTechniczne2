using MediatR;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Create
{
    public sealed record CreateMovieCommand(string Name, int Year, int SeanceTime, long MovieCategoryId)
        : IRequest<Result>;
}