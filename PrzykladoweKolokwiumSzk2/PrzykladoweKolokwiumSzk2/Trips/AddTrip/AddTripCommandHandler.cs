using MediatR;
using PrzykladoweKolokwiumSzk2.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrzykladoweKolokwiumSzk2.Trips.AddTrip
{
    public class AddTripCommandHandler : IRequestHandler<AddTripCommand, int>
    {

        private readonly TripContextDb _db; //context

        public AddTripCommandHandler(TripContextDb db) => _db = db;


        public async Task<int> Handle(AddTripCommand c, CancellationToken ct)
        {
            var trip = new Trip
            {
                Name = c.Name,
                CountryId = c.CountryId,
                Description =c.Description,
                 DateFrom = c.DateFrom,
               DateTo = c.DateTo,
                 PricePerPerson = c.PricePerPerson, 
                 HotelName = c.HotelName,   
                 AllowsPets = c.AllowsPets,

            };
            _db.Trips.Add(trip);
            await _db.SaveChangesAsync(ct);
            return trip.Id;

        }
    }


}

