using HolidayDomain.Entities;

namespace HolidayWebApplication.Models
{
    public class PropertyDetailsModel : PropertyListingModel
    {
        public string? Description { get; set; }
        public List<string> Amenities { get; set; } = new();
        public List<DateTime> BookedDates { get; set; } = new();

        public Property ToPropertyModel(int id)
        {
            return new Property
            {
                Id = id,
                Name = Name,
                Description = Description,
                Blurb = Blurb,
                Location = Location,
                NumberOfBedrooms = NumberOfBedrooms,
                CostPerNight = CostPerNight,
                Amenities = Amenities,
                BookedDates = BookedDates
            };
        }
    }
}
