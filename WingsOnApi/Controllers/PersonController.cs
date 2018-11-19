using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WingsOn.Domain;
using WingsOn.Services.Abstract;


namespace WingsOnApi.Controllers
{
    [RoutePrefix("wingson/api/person")]
    public class PersonController : BaseApiController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Get all people registered
        /// </summary>
        /// <returns>A list of people</returns>
        [ResponseType(typeof(IEnumerable<Person>))]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Content(HttpStatusCode.Forbidden, "One person at a time please");
        }

        /// <summary>
        /// Get a person by Id
        /// </summary>
        /// <param name="id">Id of person</param>
        /// <returns>Person</returns>
        [ResponseType(typeof(Person))]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= -1)
            {
                throw new ArgumentException();
            }
            return GetRequestResult(() => _personService.Get(id));
        }

        /// <summary>
        /// Get all people that are male
        /// </summary>
        /// <returns>List of male people</returns>
        [ResponseType(typeof(IEnumerable<Person>))]
        [Route("getpeoplebygender/{genderType}")]
        [HttpGet]
        public IHttpActionResult GetPeopleByGender(GenderType genderType)
        {
            return GetRequestResult(() => _personService.GetPeopleByGender(genderType));
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