using MediatR;
using Microsoft.AspNetCore.Components;
using SzkolenieTechniczne2.Cinema.Domain.Command;
using SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Create;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;
using SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetAllMoviesQuery;
using SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieCategories;
using SzkolenieTechniczne2.Cinema.Models;


namespace SzkolenieTechniczne2.Cinema.Components.Pages
{
    public partial class MovieCreate : ComponentBase
    {
        [Inject]
        public IMediator MediatorService { get; set; } = default;
        public CreateMovieFormModel Model { get; set; } = new();
        private List<MovieCategoryDto> Categories = new ();
        private List<Result.Error> ValidationErrors = new();
        private string? SuccessMessage;

        protected override async Task OnInitializedAsync()
        {
            Categories = await MediatorService.Send(new GetMovieCategoriesQuery());
        }
        private async Task HandleValidSubmit()
        {
            ValidationErrors.Clear();
            SuccessMessage = null;

            var command = new CreateMovieCommand(Model.Name, Model.Year, Model.SeanceTime, Model.MovieCategoryId);
            var result = await Mediator.Send(command);

            if (result.IsSuccess)
            {
                SuccessMessage = "Movie created Succesfully!";
                Model = new(); //reset
            }
            else {
                ValidationErrors = result.Errors.ToList();
            
            }
        }
    }
}
