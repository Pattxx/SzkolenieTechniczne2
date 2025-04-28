using SzkolenieTechniczne2.Cinema.Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace SzkolenieTechniczne2.Cinema.Domain.Entities
{
    [Table("Movies", Schema = "Cinema")]
    public class Movie: BaseEntity
    {
        protected Movie() { }
        public Movie(string name, int year, int seanceTime)//int description)#string name,int year, int seanceTime)
        {
            Name = name;
            Year = year;
            SeanceTime = seanceTime;
        }
        //public long Id { get; protected set; }

        [MaxLength(256)]
        [Required]
        public string Name { get; protected set; }

        [Range(1888,2100)]
        public int Year { get; protected set; }
        [Range(1, 600)]
        public int SeanceTime { get; protected set; }

        public virtual ICollection<MovieCategory> MovieCategories { get; protected set; }
        public virtual ICollection<Seance> Seances { get; protected set; }

        public Seance GetSeanceByDateAndRoomId(DateTime date)
            => Seances.SingleOrDefault(x => DateTime.Compare(x.Date, date) == 1);

        public void SetName(string name)
            => Name = name; //możliwa walidacja, jeżeli błedny zapis -> wyjątek

        public void SetYear(int year)
            => Year = year;

        public void SetSeanceTime(int seanceTime)
            => SeanceTime = seanceTime;

    }
}
