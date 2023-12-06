using HolidayDomain.Repositories;
using HolidayWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWebApplication.Controllers
{
    public class PropertyManagementController : Controller
    {
        private readonly IPropertyRepository _repository;

        public PropertyManagementController(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(PropertyDetailsModel propertyDetails)
        {
            if (ModelState.IsValid)
            {
                var lastPropertyId = _repository.Properties.Last().Id;
                var property = propertyDetails.ToPropertyModel(lastPropertyId++);
                _repository.AddProperty(property);
            }
            return View();
        }
    }
}
