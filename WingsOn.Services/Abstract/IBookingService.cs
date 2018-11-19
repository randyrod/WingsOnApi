using System.Collections.Generic;
using WingsOn.Domain;
using WingsOn.Domain.ViewModels;

namespace WingsOn.Services.Abstract
{
    public interface IBookingService : IService<Booking>
    {
        IEnumerable<Person> GetPassengersInFlight(string flightNumber);

        Booking GetBookingByNumber(string bookingNumber);

        PassengersInFlightViewModel GetPassengersCountInFlight(string flightNumber);
    }
}
