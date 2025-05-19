using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne2.Cinema.Common.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Entities;

[Table("Tickets", Schema = "Cinema")]
public class Ticket : BaseEntity
{
    protected Ticket()
    {
    }

    public Ticket(string email, int peopleCount, long seanceId)
    {
        Email = email;
        SeanceId = seanceId;
        PeopleCount = peopleCount;
        CreatedOn = DateTime.UtcNow;      
    }

    [MaxLength(256)]
    [Required]
    public string Email { get; protected set; }
    [Range(1, 100)]
    public int PeopleCount { get; protected set; }


    public long SeanceId { get; protected set; }
    public Seance Seance { get; protected set; }
}