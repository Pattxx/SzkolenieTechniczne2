using MediatR;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieQuery
{
    public sealed record GetMovieQuery(long MovieId) : IRequest<MovieDetailsDto>;
}
