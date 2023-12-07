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
                var property = propertyDetails.ToPropertyModel();
                _repository.Add(property);

                ModelState.Clear();
            }
            return View();
        }
    }
}
