using System.Collections.Generic;
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
            
            Assert.IsInstanceOfType(getResponse, typeof(Person));
        }

        [TestMethod]
        public void GetAll()
        {
            var controller = new PersonController(_personService);

            var getAllResponse = controller.Get();
            
            Assert.IsNotNull(getAllResponse);
            Assert.IsInstanceOfType(getAllResponse, typeof(IEnumerable<Person>));
        }

        [TestMethod]
        public void TestAllMale()
        {
            var controller = new PersonController(_personService);

            var maleResponse = controller.GetAllMale();
            
            Assert.IsNotNull(maleResponse);
            Assert.IsInstanceOfType(maleResponse, typeof(IEnumerable<Person>));
        }
    }
}