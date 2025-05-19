namespace SzkolenieTechniczne2.Cinema.Domain.Query.Dtos
{
    public sealed record TicketDetailsDto(
     long Id,
     string Email,
     int PeopleCount,
     DateTime PurchaseDate
 );
}
