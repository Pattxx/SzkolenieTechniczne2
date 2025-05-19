using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.DTOS
{
    public sealed record SeanceDto(
        long Id,
        DateTime Date
        );
}
