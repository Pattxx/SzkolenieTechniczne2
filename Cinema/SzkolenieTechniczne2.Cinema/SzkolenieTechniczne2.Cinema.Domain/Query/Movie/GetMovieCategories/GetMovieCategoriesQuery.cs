using MediatR;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieCategories
{
   public class GetMovieCategoriesQuery : IRequest<List<MovieCategoryDto>>
    {

    }
}
