using MediatR;
using Microsoft.AspNetCore.Components;
using SzkolenieTechniczne2.Cinema.Domain.Command;
using SzkolenieTechniczne2.Cinema.Domain.Entities;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;
using SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieCategories;
using SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieQuery;
using SzkolenieTechniczne2.Cinema.Models;

namespace SzkolenieTechniczne2.Cinema.Components.Pages
{
    public partial class MovieDetails : ComponentBase
    {
        [Inject]
        public IMediator MediatorService { get; set; } = default;
        [Inject]
        public NavigationManager Navigation { get; set; } = default;
        /// <summary>
        /// [Parameter]
        /// </summary>
        private long MovieId { get; set; }

        private MovieDetailsDto? Details;
       

        protected override async Task OnInitializedAsync()
        {
            Details = await MediatorService.Send(new GetMovieQuery(MovieId));
        }


        private void GoBack() {
            Navigation.NavigateTo("/movies");
        }

    }
}
