using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;
using WingsOn.Services.Abstract;

namespace WingsOnApi.Controllers
{
    public class PersonController : ApiController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Content(HttpStatusCode.OK, _personService.GetAll(), new JsonMediaTypeFormatter());
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Content(HttpStatusCode.OK, _personService.Get(id), new JsonMediaTypeFormatter());
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