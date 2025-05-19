using FluentValidation;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Update
{
    class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty()
           .WithMessage("ID filmu jest wymagane.");
             
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nazwa filmu jest wymagana");

            RuleFor(x => x.Year)
                .InclusiveBetween(1900, 2040)
                .WithMessage("Rok musi być pomiędzy 1900 a 2080.");

            RuleFor(x => x.SeanceTime)
                .InclusiveBetween(30, 300)
               .WithMessage("Seans musi być pomiędzy 30 and 300 minutes.");
        }
    }
}
