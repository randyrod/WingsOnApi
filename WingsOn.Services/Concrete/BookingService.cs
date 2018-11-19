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

            GetAll().Where(b => string.Equals(b.Flight.Number, flightNumber, StringComparison.CurrentCultureIgnoreCase))
                .ToList().ForEach(booking =>
            {
                passengers.AddRange(booking.Passengers);
            });

            return passengers.Any() ? passengers : null;
        }

        public Booking GetBookingByNumber(string bookingNumber)
        {
            return GetAll().SingleOrDefault(b => string.Equals(b.Number, bookingNumber, StringComparison.CurrentCultureIgnoreCase));
        }

        public PassengersInFlightViewModel GetPassengersCountInFlight(string flightNumber)
        {
            var passengersInFlight = GetPassengersInFlight(flightNumber);

            if (passengersInFlight != null)
            {
                return new PassengersInFlightViewModel
                {
                    FlightNumber = flightNumber,
                    PassengerAmount = passengersInFlight.Count()
                };
            }
            
            throw new ElementNotFoundException($"No flight with the number: {flightNumber} was found");
        }
    }
}
