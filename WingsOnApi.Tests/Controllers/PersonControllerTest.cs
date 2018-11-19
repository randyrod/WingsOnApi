using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WingsOn.Domain;
using WingsOn.Services.Abstract;
using WingsOnApi.Controllers;
using WingsOnApi.Tests.TestUtils;

namespace WingsOnApi.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        private readonly IPersonService _personService;

        public PersonControllerTest()
        {
            _personService = NinjectHelper.Get<IPersonService>();
        }
        
        [TestMethod]
        public void Get()
        {
            var controller = new PersonController(_personService);

            var getResponse = controller.Get(91);

            Assert.IsNotNull(getResponse);
            Assert.IsInstanceOfType(getResponse, typeof(FormattedContentResult<Person>));
   
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetException()
        {
            var controller = new PersonController(_personService);

            var getResponse = controller.Get(-1);
        }
        
        [TestMethod]
        public void GetAll()
        {
            var controller = new PersonController(_personService);

            var getAllResponse = controller.Get();
            
            Assert.IsNotNull(getAllResponse);
            Assert.IsInstanceOfType(getAllResponse, typeof(NegotiatedContentResult<string>));

            var result = getAllResponse as NegotiatedContentResult<string>;
            
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Forbidden, result.StatusCode);
        }

        [TestMethod]
        public void TestGetPassengersByGender()
        {
            var controller = new PersonController(_personService);

            var maleResponse = controller.GetPeopleByGender(GenderType.Male);
            
            Assert.IsNotNull(maleResponse);
            Assert.IsInstanceOfType(maleResponse, typeof(FormattedContentResult<IEnumerable<Person>>));
        }
        
        [TestMethod]
        public void GetNotFound()
        {
            var controller = new PersonController(_personService);

            var getResponse = controller.Get(1000);

            Assert.IsNotNull(getResponse);
            Assert.IsInstanceOfType(getResponse, typeof(FormattedContentResult<string>));

            var result = getResponse as FormattedContentResult<string>;

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Post()
        {
            var controller = new PersonController(_personService);
            
            controller.Post("Test");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Put()
        {
            var controller = new PersonController(_personService);
            
            controller.Put(0, "Test");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Delete()
        {
            var controller = new PersonController(_personService);
            
            controller.Delete(0);
        }
        
        
    }
}