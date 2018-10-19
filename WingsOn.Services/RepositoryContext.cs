﻿using WingsOn.Dal;

namespace WingsOn.Services
{
    public class RepositoryContext
    {
        public AirlineRepository AirlineRepository;
        public AirportRepository AirportRepository;
        public BookingRepository BookingRepository;
        public FlightRepository FlightRepository;
        public PersonRepository PersonRepository;

        public RepositoryContext()
        {
            AirportRepository = new AirportRepository();
            AirportRepository = new AirportRepository();
            BookingRepository = new BookingRepository();
            FlightRepository = new FlightRepository();
            PersonRepository = new PersonRepository();
        }
    }
}
