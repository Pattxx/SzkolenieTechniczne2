using System.ComponentModel.DataAnnotations;

namespace SzkolenieTechniczne2.Cinema.Models
{
    public class CreateMovieFormModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }   
        public int SeanceTime { get; set; }
        public long MovieCategoryId { get; set; }   
    }
}
