using HolidayDomain.Entities;
using HolidayDomain.Repositories;
using HolidayWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWebApplication.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _repository;
        private readonly UserManager<IdentityUser> _manager;

        public BookingController(
            IBookingRepository repository, UserManager<IdentityUser> manager)
        {
            _repository = repository;
            _manager = manager;
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
        public IActionResult SubmitBooking(
            int propertyId, DateTime startDate, DateTime endDate, string userEmail, string billingAddress)
        {
            var userId = _manager.Users.FirstOrDefault()?.Id;

            var booking = new Booking
            {
                PropertyId = propertyId,
                StartDate = startDate,
                EndDate = endDate,
                UserId = userId,
                UserEmail = userEmail,
                BillingAddress = billingAddress
            };
            booking = _repository.MakeBooking(booking);

            if (booking != null)
                return View("BookingSuccess", booking);
            else
                return View("BookingFailure");
        }
    }
}
