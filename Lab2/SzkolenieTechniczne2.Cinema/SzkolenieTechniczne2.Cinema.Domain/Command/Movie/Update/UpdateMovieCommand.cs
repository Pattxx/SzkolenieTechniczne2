using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//NA KOLOKWIUM
namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Update
{
    public sealed record UpdateMovieCommand(string Name, int Year, int SeanceTime, long MovieCategoryId, long movieId) : IRequest<Result>;
   
}
