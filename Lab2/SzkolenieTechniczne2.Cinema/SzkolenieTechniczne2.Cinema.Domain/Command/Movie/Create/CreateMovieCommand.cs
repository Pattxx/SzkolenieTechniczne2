using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Create
{
    //single line declaration

    public sealed record CreateMovieCommand(string Name, int Year, int SeanceTime, long MovieCategoryId) : IRequest<Result>;
    
}
