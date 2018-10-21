﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http.Formatting;
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
            return GetRequestResult(() => _personService.GetAll());
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
            return GetRequestResult(() => _personService.Get(id));
        }

        /// <summary>
        /// Get all people that are male
        /// </summary>
        /// <returns>List of male people</returns>
        [ResponseType(typeof(IEnumerable<Person>))]
        [Route("getmales")]
        [HttpGet]
        public IHttpActionResult GetAllMale()
        {
            return GetRequestResult(() => _personService.GetAllMalePassengers());
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