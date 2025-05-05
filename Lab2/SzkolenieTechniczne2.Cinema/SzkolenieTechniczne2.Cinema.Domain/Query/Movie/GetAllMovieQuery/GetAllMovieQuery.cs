using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Query.DTOS;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetAllMovieQuery
{
    public sealed record GetAllMovieQuery : IRequest<List<MovieDto>>
    {
    }
}
