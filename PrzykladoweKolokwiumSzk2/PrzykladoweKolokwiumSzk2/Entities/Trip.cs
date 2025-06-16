using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweKolokwiumSzk2.Entities
{
    [Table("Triops", Schema = "kolokwium")]
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public int CountryId { get; set; }
        public Country Country { get; set; } = default!;

        public string Description { get; set; } = string.Empty;
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }

        public decimal PricePerPerson { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public bool AllowsPets { get; set; }
    }
}
