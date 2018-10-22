using WingsOn.Dal;

namespace WingsOn.Services
{
    public class WingsOnDbContext
    {
        public readonly AirlineRepository AirlineRepository;
        public readonly AirportRepository AirportRepository;
        public readonly BookingRepository BookingRepository;
        public readonly FlightRepository FlightRepository;
        public readonly PersonRepository PersonRepository;

        public WingsOnDbContext()
        {
            AirportRepository = new AirportRepository();
            AirportRepository = new AirportRepository();
            BookingRepository = new BookingRepository();
            FlightRepository = new FlightRepository();
            PersonRepository = new PersonRepository();
            AirlineRepository = new AirlineRepository();
        }
    }
}
