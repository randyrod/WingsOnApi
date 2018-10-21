using System.Collections.Generic;
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
            return GetRequestResult(() => _bookingService.GetAll());
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
            return GetRequestResult(() => _bookingService.GetPassengersInFlight(flightNumber));
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
            return GetRequestResult(() => _bookingService.GetPassengersCountInFlight(flightNumber));
        }
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}