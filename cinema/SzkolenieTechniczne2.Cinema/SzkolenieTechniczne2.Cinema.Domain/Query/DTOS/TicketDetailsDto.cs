using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.DTOS
{
    public sealed record TicketDetailsDto(
         long Id,
         string Email,
         int PeopleCount,
         DateTime PurchaseDate
         );
}
