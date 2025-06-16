using MediatR;
using Microsoft.AspNetCore.Components;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;
using SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetAllMoviesQuery;

namespace SzkolenieTechniczne2.Cinema.Components.Pages
{
    public partial class Movies: ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; } = default;

        public List<MovieDto>? MovieList;
        [Inject]
        public IMediator MediatorService { get; set; } = default;

        protected override async Task OnInitializedAsync()
        {
            MovieList = await MediatorService.Send(new GetAllMoviesQuery());
        }

        private void GoToDetails(long movieId)
        {
            Navigation.NavigateTo($"/movies/details/{movieId}");
        }

        private async Task DeleteMovie(long movieId)
        {

        }

    }
}
