using MediatR;

namespace PrzykladoweKolokwiumSzk2.Trips.GetTrips
{
    public record GetTripsQuery(): IRequest<IReadOnlyList<TripDto>>;

}
