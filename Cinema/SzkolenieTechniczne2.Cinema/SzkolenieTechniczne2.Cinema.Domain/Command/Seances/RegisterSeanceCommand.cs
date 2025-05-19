using MediatR;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Seances
{
    public sealed record RegisterSeanceCommand(long MovieId, DateTime SeanceDate) : IRequest<Result>;

}
