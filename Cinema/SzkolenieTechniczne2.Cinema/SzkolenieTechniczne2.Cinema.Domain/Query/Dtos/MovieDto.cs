using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;

public sealed record MovieDto(long Id, string Name);

//public class MovieDto
//{
//    public MovieDto(string name, long id)
//    {
//        Name = name;
//        Id = id;
//    }

//    public string Name { get; }

//    public long Id { get; }
//}
