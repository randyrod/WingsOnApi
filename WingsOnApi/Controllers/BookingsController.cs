using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Description;
using WingsOn.Domain;
using WingsOn.Services.Abstract;

namespace WingsOnApi.Controllers
{
    [RoutePrefix("wingson/api/bookings")]
    public class BookingsController : BaseApiController
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// Get all bookings
        /// </summary>
        /// <returns>List of bookings</returns>
        [ResponseType(typeof(IEnumerable<Booking>))]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Content(HttpStatusCode.Forbidden, "You can't have everything in life, in this case bookings");
        }

        /// <summary>
        /// Get booking by id
        /// </summary>
        /// <param name="id">Id of booking</param>
        /// <returns>Booking</returns>
        [ResponseType(typeof(Booking))]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            if ( id <= 0)
            {
                throw new ArgumentException();
            }
            
            return GetRequestResult(() => _bookingService.Get(id));
        }

        /// <summary>
        /// Get passengers in a flight
        /// </summary>
        /// <param name="flightNumber">Number of flight</param>
        /// <returns>List of passengers</returns>
        [ResponseType(typeof(IEnumerable<Person>))]
        [Route("getpassengersinflight/{flightNumber}")]
        public IHttpActionResult GetPassengersInFlight(string flightNumber)
        {
            if (string.IsNullOrEmpty(flightNumber))
            {
                throw new ArgumentNullException();
            }
            
            return GetRequestResult(() => _bookingService.GetPassengersInFlight(flightNumber));
        }
        
        /// <summary>
        /// Get booking by booking number
        /// </summary>
        /// <param name="bookingNumber">Number of booking</param>
        /// <returns>Booking</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [ResponseType(typeof(Booking))]
        [Route("{bookingNumber}")]
        public IHttpActionResult Get(string bookingNumber)
        {
            if (string.IsNullOrEmpty(bookingNumber))
            {
                throw new ArgumentNullException();
            }

            return GetRequestResult(() => _bookingService.GetBookingByNumber(bookingNumber));
        }

        /// <summary>
        /// Get passengers in a flight
        /// </summary>
        /// <param name="flightNumber">Number of flight</param>
        /// <returns>List of passengers</returns>
        [ResponseType(typeof(int))]
        [Route("getpassengerscountinflight/{flightNumber}")]
        public IHttpActionResult GetPassengerCountInFlight(string flightNumber)
        {
            if (string.IsNullOrEmpty(flightNumber))
            {
                throw new ArgumentNullException();
            }
            
            return GetRequestResult(() => _bookingService.GetPassengersCountInFlight(flightNumber));
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}