using MediatR;
using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwiumSzk2.Trips.GetCountries;
using PrzykladoweKolokwiumSzk2.Entities;
namespace PrzykladoweKolokwiumSzk2.Trips.GetTrips
{
    public class GetTripsQueryHandler : IRequestHandler<GetTripsQuery, IReadOnlyList<TripDto>>
    {

        private readonly TripContextDb _db; //context

        public GetTripsQueryHandler(TripContextDb db) => _db = db;


        public async Task<IReadOnlyList<TripDto>> Handle(GetTripsQuery query, CancellationToken ct)
                => await _db.Trips.AsNoTracking()
                                       .Include(c => c.Country) //tutaj include bo pusta bedzie
                                       .Select(c => new TripDto {
                                           Id = c.Id,
                                           Name = c.Name,
                                           Country = c.Country.Name, //tu musi być odniesienie do nazwy kraju
                                           DateFrom = c.DateFrom,
                                           DateTo = c.DateTo,
                                           PricePerPerson = c.PricePerPerson
                                       })
                                       .ToListAsync(ct);

    }
}
