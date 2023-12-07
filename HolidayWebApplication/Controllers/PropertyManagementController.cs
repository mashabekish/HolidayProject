using HolidayDomain.Repositories;
using HolidayWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWebApplication.Controllers
{
    public class PropertyManagementController : Controller
    {
        private readonly IPropertyRepository _repository;
        private readonly IWebHostEnvironment _environment;

        public PropertyManagementController(
            IPropertyRepository repository, IWebHostEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
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

        public IActionResult AddImage(int id)
        {
            var model = new AddImageModel { PropertyId = id };
            return View(model);
        }

        [HttpPost]
        public IActionResult UploadImage(AddImageModel model)
        {
            if (model.Image != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.Image.FileName)}";
                var urlPath = $"/images/{fileName}";
                var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }

                _repository.AddPropertyImage(model.PropertyId, urlPath);
            }

            return RedirectToAction("ViewPropertyDetails", "PropertyListing", new { id = model.PropertyId });
        }
    }
}
