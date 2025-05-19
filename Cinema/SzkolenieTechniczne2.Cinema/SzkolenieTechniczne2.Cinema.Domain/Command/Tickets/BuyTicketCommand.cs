using MediatR;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Tickets
{
    public sealed record BuyTicketCommand(
    Guid MovieId,
    DateTime SeanceDate,
    string Email,
    int Quantity
) : IRequest<Result>;
}
