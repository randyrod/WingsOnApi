using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain;
using WingsOn.Domain.ViewModels;
using WingsOn.Services.Abstract;
using WingsOn.Services.CustomExceptions;

namespace WingsOn.Services.Concrete
{
    public class BookingService : ServiceBase, IBookingService
    {
        public BookingService()
        {
            WingsOnDbContext = new WingsOnDbContext();
        }

        public Booking Get(int id)
        {
            var booking =  WingsOnDbContext.BookingRepository.Get(id);

            if (booking != null)
            {
                return booking;
            }
            
            throw new ElementNotFoundException($"There was no booking found with id: {id}");
        }

        public IEnumerable<Booking> GetAll() => WingsOnDbContext.BookingRepository.GetAll();

        public IEnumerable<Person> GetPassengersInFlight(string flightNumber)
        {
            var passengers = new List<Person>();

            var bookings = GetAll().Where(b => string.Equals(b.Flight.Number, flightNumber, StringComparison.CurrentCultureIgnoreCase)).ToArray();

            if (!bookings.Any())
            {
                throw new ElementNotFoundException($"There was no flight found with number: {flightNumber}");
            }
            
            foreach (var booking in bookings)
            {
                passengers.AddRange(booking.Passengers);
            }

            if (passengers.Any())
            {
                return passengers;
            }
            
            throw new ElementNotFoundException($"There were no passengers found for flight number: {flightNumber}");
        }

        public Booking GetBookingByNumber(string bookingNumber)
        {
            var booking = GetAll().SingleOrDefault(b => string.Equals(b.Number, bookingNumber, StringComparison.CurrentCultureIgnoreCase));

            if (booking != null)
            {
                return booking;
            }
            
            throw new ElementNotFoundException($"There was no booking found with the number: {bookingNumber}");
        }

        public PassengersInFlightViewModel GetPassengersCountInFlight(string flightNumber)
        {
            var passengersInFlight = GetPassengersInFlight(flightNumber);

            return new PassengersInFlightViewModel
            {
                FlightNumber = flightNumber,
                PassengerAmount = passengersInFlight.Count()
            };
        }
    }
}
