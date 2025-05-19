using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Common.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Entities
{
    public class MovieCategory: BaseEntity
    {
        public MovieCategory() { }

        public virtual ICollection<Movie> Movies { get; protected set; }
    }
}
