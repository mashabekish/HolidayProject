using HolidayDomain.Repositories;
using HolidayWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWebApplication.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _repository;

        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult BookProperty(DateTime start, DateTime end, int propertyId)
        {
            var booking = new CreateBookingModel
            {
                PropertyId = propertyId,
                StartDate = start,
                EndDate = end
            };
            return View("CreateBooking", booking);
        }

        [HttpPost]
        public IActionResult SubmitBooking(int propertyId, DateTime startDate, DateTime endDate, string userEmail, string billingAddress)
        {
            var booking = _repository.MakeBooking(propertyId, startDate, endDate, userEmail, billingAddress);

            if (booking != null)
                return View("BookingSuccess", booking);
            else
                return View("BookingFailure");
        }
    }
}
