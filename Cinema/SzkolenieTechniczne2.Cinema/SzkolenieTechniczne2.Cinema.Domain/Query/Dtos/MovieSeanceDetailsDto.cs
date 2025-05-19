
using SzkolenieTechniczne2.Cinema.Domain.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Dtos
{
    public sealed record MovieSeanceDetailsDto(
     long MovieId,
     long SeanceId,
     string MovieName,
     DateTime SeanceDate);
}
