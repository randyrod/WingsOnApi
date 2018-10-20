using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;
using WingsOn.Services.Abstract;

namespace WingsOnApi.Controllers
{
    public class BookingsController : ApiController
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Content(HttpStatusCode.OK, _bookingService.GetAll(), new JsonMediaTypeFormatter());
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Content(HttpStatusCode.OK, _bookingService.Get(id), new JsonMediaTypeFormatter());
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