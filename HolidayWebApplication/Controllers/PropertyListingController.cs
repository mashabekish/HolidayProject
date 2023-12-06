using HolidayWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HolidayWebApplication.Controllers
{
    public class PropertyListingController : Controller
    {
        private readonly List<PropertyDetailsModel> _properties = new()
        {
            new () {
                Id = 1,
                Name = "Rose Cottage",
                Blurb = "Beautiful cottage on the Cornwall coast",
                Location = "Cornwall",
                NumberOfBedrooms = 3,
                CostPerNight = 350,
                Description = "Very comfortable and nice for a relaxing holiday",
                Amenities = new() { "Swimming pool", "Terrace", "Barbecue" },
                BookedDates = new() { DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-9), DateTime.Now.AddDays(-8) }
            },
            new () {
                Id = 2,
                Name = "Safron House",
                Blurb = "Stately home on the Devon moores",
                Location = "Devon",
                NumberOfBedrooms = 7,
                CostPerNight = 730,
                Description = "Very presentable and attractive house",
                Amenities = new() { "Garden", "Terrace", "Pond" },
                BookedDates = new() { DateTime.Now.AddDays(-9), DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-7) }
            }
        };

        public IActionResult ListAll()
        {
            return View("ListProperties", _properties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            var availableProperties = _properties
                .Where(p => p.BookedDates.All(d => d < start || d > end))
                .ToList();
            return View("ListProperties", availableProperties);
        }

        public IActionResult ViewPropertyDetails(int id)
        {
            var property = _properties.FirstOrDefault(p => p.Id == id);

            if (property == null)
                return NotFound();

            return View("PropertyDetails", property);
        }
    }
}
