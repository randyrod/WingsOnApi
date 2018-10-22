using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain;
using WingsOn.Services.Abstract;

namespace WingsOn.Services.Concrete
{
    public class BookingService : ServiceBase, IBookingService
    {
        public BookingService()
        {
            WingsOnDbContext = new WingsOnDbContext();
        }

        public Booking Get(int id) => WingsOnDbContext.BookingRepository.Get(id);

        public IEnumerable<Booking> GetAll() => WingsOnDbContext.BookingRepository.GetAll();

        public IEnumerable<Person> GetPassengersInFlight(string flightNumber)
        {
            var passengers = new List<Person>();

            GetAll().Where(b => b.Flight.Number == flightNumber).ToList().ForEach(booking =>
            {
                passengers.AddRange(booking.Passengers);
            });

            return passengers;
        }

        public Booking GetBookingByNumber(string bookingNumber)
        {
            return GetAll().SingleOrDefault(b => b.Number == bookingNumber);
        }

        public int GetPassengersCountInFlight(string flightNumber)
        {
            return GetPassengersInFlight(flightNumber).Count();
        }
    }
}
