using MediatR;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Delete
{
    public sealed record DeleteMovieCommand(long Id) : IRequest<Result>;    
}
