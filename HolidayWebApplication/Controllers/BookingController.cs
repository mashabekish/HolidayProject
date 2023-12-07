using HolidayDomain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWebApplication.Controllers
{
    public class BookingController : Controller
    {
        private readonly IPropertyRepository _repository;

        public BookingController(IPropertyRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult BookProperty(DateTime start, DateTime end, int propertyId)
        {
            _repository.BookProperty(propertyId, start, end);
            return RedirectToAction("ListAll", "PropertyListing");
        }
    }
}
