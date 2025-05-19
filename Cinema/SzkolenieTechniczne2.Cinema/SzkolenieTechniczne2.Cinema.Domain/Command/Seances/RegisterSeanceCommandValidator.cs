using FluentValidation;
namespace SzkolenieTechniczne2.Cinema.Domain.Command.Seances;

internal class RegisterSeanceCommandValidator : AbstractValidator<RegisterSeanceCommand>
{
    public RegisterSeanceCommandValidator()
    {
        RuleFor(x => x.MovieId)
            .NotEmpty()
            .WithMessage("ID filmu jest wymagane.");

        RuleFor(x => x.SeanceDate)
            .NotEmpty()
        .WithMessage("Data seansu jest wymagane.")
        .GreaterThan(DateTime.UtcNow)
            .WithMessage("Data seansu musi być większa niż aktualna");
    }
}
