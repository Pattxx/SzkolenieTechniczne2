using MediatR;
using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwiumSzk2.Entities;
using PrzykladoweKolokwiumSzk2.Trips.AddTrip;

namespace PrzykladoweKolokwiumSzk2.Trips.GetCountries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IReadOnlyList<CountryDto>>
    {

        private readonly TripContextDb _db; //context

        public GetCountriesQueryHandler(TripContextDb db) => _db = db;


        public async Task<IReadOnlyList<CountryDto>> Handle(GetCountriesQuery query, CancellationToken ct)
                => await _db.Countries.AsNoTracking()
                                       .OrderBy(c => c.Name)
                                       .Select(c => new CountryDto {Id=c.Id, Name=c.Name })
                                       .ToListAsync(ct);
       
    }
}
