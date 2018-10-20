using System.Collections.Generic;
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
            Assert.IsInstanceOfType(getAllResponse, typeof(IEnumerable<Booking>));
        }
        
        [TestMethod]
        public void Get()
        {
            var controller = new BookingsController(_bookingService);

            var getAllResponse = controller.Get(83);
            
            Assert.IsNotNull(getAllResponse);
            Assert.IsInstanceOfType(getAllResponse, typeof(Booking));
        }

        [TestMethod]
        public void GetPassengersInFlight()
        {
            var controller = new BookingsController(_bookingService);

            var passengersInFlight = controller.GetPassengersInFlight("PZ696");
            
            Assert.IsNotNull(passengersInFlight);
            Assert.IsInstanceOfType(passengersInFlight, typeof(IEnumerable<Person>));
        }
        
    }
}