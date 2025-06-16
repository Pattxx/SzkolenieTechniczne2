using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweKolokwiumSzk2.Entities
{
    [Table("Countries", Schema = "kolokwium")]
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = default!;

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
