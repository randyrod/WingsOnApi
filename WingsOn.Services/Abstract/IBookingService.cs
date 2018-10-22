using System.Collections.Generic;
using WingsOn.Domain;

namespace WingsOn.Services.Abstract
{
    public interface IBookingService : IService<Booking>
    {
        IEnumerable<Person> GetPassengersInFlight(string flightNumber);

        Booking GetBookingByNumber(string bookingNumber);

        int GetPassengersCountInFlight(string flightNumber);
    }
}
