using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne2.Cinema.Common.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Entities
{
    [Table("Tickets", Schema = "Cinema")]
    public class Ticket: BaseEntity
    {
        protected Ticket() { }
        public Ticket(string name, DateTime purchaseDate, int peopleCount)
        {
            Email = name;
            PeopleCount = peopleCount;
            PurchaseDate = DateTime.UtcNow;
        }
    
        public string Email { get;protected set; }
        public DateTime PurchaseDate { get;protected set; }
        public int PeopleCount { get; protected set; }

    }
}
