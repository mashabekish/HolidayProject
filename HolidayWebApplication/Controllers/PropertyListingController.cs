using HolidayDomain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWebApplication.Controllers
{
    public class PropertyListingController : Controller
    {
        private readonly IPropertyRepository _repository;

        public PropertyListingController(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public IActionResult ListAll()
        {
            return View("ListProperties", _repository.Properties.ToList());
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            var availableProperties = _repository.Properties
                //.Where(p => p.BookedNights.All(d => d < start || d > end))
                .ToList();
            return View("ListProperties", availableProperties);
        }

        public IActionResult ViewPropertyDetails(int id)
        {
            var property = _repository.Properties.FirstOrDefault(p => p.Id == id);

            if (property == null)
                return NotFound();

            return View("PropertyDetails", property);
        }
    }
}
