using MediatR;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Update
{
    public sealed record UpdateMovieCommand(long Id, string Name, int Year, int SeanceTime, long MovieCategoryId)
        : IRequest<Result>;
    
}