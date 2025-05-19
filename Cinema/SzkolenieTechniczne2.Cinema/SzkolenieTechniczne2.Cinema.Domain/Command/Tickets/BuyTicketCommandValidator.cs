using FluentValidation;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Tickets;

internal class BuyTicketCommandValidator : AbstractValidator<BuyTicketCommand>
{
    public BuyTicketCommandValidator()
    {
        RuleFor(x => x.MovieId)
            .NotEmpty()
            .WithMessage("ID filmu jest wymagane.");

        RuleFor(x => x.SeanceDate)
            .NotEmpty()
            .WithMessage("Seance date is required.");

        RuleFor(x => x.Email)
            .NotEmpty()
             .WithMessage("Email filmu jest wymagane.")
            .EmailAddress()
            .WithMessage("Nie poprawny adres email");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Liczba biletów musi być  większa od zera");
    }
}