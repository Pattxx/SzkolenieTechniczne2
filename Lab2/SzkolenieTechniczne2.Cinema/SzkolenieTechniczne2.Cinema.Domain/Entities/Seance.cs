using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne2.Cinema.Common.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Entities;

[Table("Seances", Schema = "Cinema")]
public class Seance: BaseEntity
{
    protected Seance() { }
    public Seance(int id, DateTime time, int seatsAvailable)
    {
        Id = id;
        Date = time;
        SeatsAvailable = seatsAvailable;
    }

    public int Id { get; protected set; }
    public DateTime Date { get;protected set; }
    public long MovieId {  get; protected set; }
    public Movie Movie { get; protected set; }
    public int SeatsAvailable { get; protected set; }
    public List<Ticket> GetTicketByEmail(string email) {
        throw new NotImplementedException();
        return null;//TODO
    }

    public List<Ticket> GetAllSeanceTickets()
    {
        throw new NotImplementedException();
        return null;//TODO
    }

    public void Add(Ticket ticket) {
        throw new NotImplementedException();
        //TODO;
    }

}
