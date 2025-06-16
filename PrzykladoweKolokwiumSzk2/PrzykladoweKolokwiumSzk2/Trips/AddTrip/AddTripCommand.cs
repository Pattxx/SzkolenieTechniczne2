using MediatR;
using PrzykladoweKolokwiumSzk2.Entities;

namespace PrzykladoweKolokwiumSzk2.Trips.AddTrip
{
 public sealed record AddTripCommand(
    string Name,
    int CountryId, 
    string Description,
    DateOnly DateFrom, 
    DateOnly DateTo, 
    decimal PricePerPerson, 
    string HotelName, 
    bool AllowsPets 
     ) : IRequest<int>; //Zwracamy Id nowej wycieczki
}
