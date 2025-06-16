using MediatR;

namespace PrzykladoweKolokwiumSzk2.Trips.GetCountries
{
    public record GetCountriesQuery(): IRequest<IReadOnlyList<CountryDto>>;
   
}
