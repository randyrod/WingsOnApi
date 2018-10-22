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
    public class BookingsControllerTest
    {
        private readonly IBookingService _bookingService;

        public BookingsControllerTest()
        {
            _bookingService = NinjectHelper.Get<IBookingService>();
        }

        [TestMethod]
        public void GetAll()
        {
            var controller = new BookingsController(_bookingService);

            var getAllResponse = controller.Get();

            Assert.IsNotNull(getAllResponse);
            Assert.IsInstanceOfType(getAllResponse, typeof(NegotiatedContentResult<string>));

            var result = getAllResponse as NegotiatedContentResult<string>;

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Forbidden, result.StatusCode);
        }
        
        [TestMethod]
        public void Get()
        {
            var controller = new BookingsController(_bookingService);

            var getAllResponse = controller.Get(83);
            
            Assert.IsNotNull(getAllResponse);
            Assert.IsInstanceOfType(getAllResponse, typeof(FormattedContentResult<Booking>));
        }
        
        [TestMethod]
        public void GetNotFound()
        {
            var controller = new BookingsController(_bookingService);

            var getResponse = controller.Get(1000);

            Assert.IsNotNull(getResponse);
            Assert.IsInstanceOfType(getResponse, typeof(FormattedContentResult<string>));

            var result = getResponse as FormattedContentResult<string>;

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetException()
        {
            var controller = new BookingsController(_bookingService);

            var getResponse = controller.Get(-1);
        }

        [TestMethod]
        public void GetPassengersInFlight()
        {
            var controller = new BookingsController(_bookingService);

            var passengersInFlight = controller.GetPassengersInFlight("PZ696");
            
            Assert.IsNotNull(passengersInFlight);
            Assert.IsInstanceOfType(passengersInFlight, typeof(FormattedContentResult<IEnumerable<Person>>));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPassengersInFlightException()
        {
            var controller = new BookingsController(_bookingService);

            var passengersInFlight = controller.GetPassengersInFlight("");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPassengerCountInFlight()
        {
            var controller = new BookingsController(_bookingService);

            var passengersInFlight = controller.GetPassengersInFlight("");
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Post()
        {
            var controller = new BookingsController(_bookingService);
            
            controller.Post("Test");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Put()
        {
            var controller = new BookingsController(_bookingService);
            
            controller.Put(0, "Test");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Delete()
        {
            var controller = new BookingsController(_bookingService);
            
            controller.Delete(0);
        }
        
    }
}