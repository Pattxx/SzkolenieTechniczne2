using MediatR;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Seances
{
    public sealed record GetSeanceQuery(long MovieId, long SeanceId) : IRequest<MovieSeanceDetailsDto>;
}
