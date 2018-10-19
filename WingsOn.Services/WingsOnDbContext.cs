using WingsOn.Dal;

namespace WingsOn.Services
{
    public class WingsOnDbContext
    {
        public AirlineRepository AirlineRepository;
        public AirportRepository AirportRepository;
        public BookingRepository BookingRepository;
        public FlightRepository FlightRepository;
        public PersonRepository PersonRepository;

        public WingsOnDbContext()
        {
            AirportRepository = new AirportRepository();
            AirportRepository = new AirportRepository();
            BookingRepository = new BookingRepository();
            FlightRepository = new FlightRepository();
            PersonRepository = new PersonRepository();
        }
    }
}
