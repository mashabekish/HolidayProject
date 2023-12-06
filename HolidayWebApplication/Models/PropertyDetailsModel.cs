using HolidayDomain.Entities;

namespace HolidayWebApplication.Models
{
    public class PropertyDetailsModel : PropertyListingModel
    {
        public PropertyDetailsModel()
        {
        }

        public PropertyDetailsModel(Property property)
            : base(property)
        {
            Description = property.Description;
            BookedNights = property.BookedNights
                .Select(n => n.Night)
                .ToList();
        }

        public string? Description { get; set; }
        public List<DateTime> BookedNights { get; set; } = new();

        public Property ToPropertyModel()
        {
            return new Property
            {
                Name = Name,
                Description = Description,
                Blurb = Blurb,
                Location = Location,
                NumberOfBedrooms = NumberOfBedrooms,
                CostPerNight = CostPerNight
            };
        }
    }
}
