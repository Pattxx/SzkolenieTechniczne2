using PrzykladoweKolokwiumSzk2.Entities;

namespace PrzykladoweKolokwiumSzk2.Trips.GetTrips
{
    public sealed class TripDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
        public decimal PricePerPerson { get; set; }
 
    }
}
