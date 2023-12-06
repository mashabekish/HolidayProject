using HolidayDomain.Entities;

namespace HolidayDomain.Repositories
{
    public class DummyPropertyRepository : IPropertyRepository
    {
        private readonly List<Property> _properties = new()
        {
            new () {
                Id = 1,
                Name = "Rose Cottage",
                Blurb = "Beautiful cottage on the Cornwall coast",
                Location = "Cornwall",
                NumberOfBedrooms = 3,
                CostPerNight = 350,
                Description = "Very comfortable and nice for a relaxing holiday",
                BookedNights = new()
            },
            new () {
                Id = 2,
                Name = "Safron House",
                Blurb = "Stately home on the Devon moores",
                Location = "Devon",
                NumberOfBedrooms = 7,
                CostPerNight = 730,
                Description = "Very presentable and attractive house",
                BookedNights = new()
            }
        };

        public IEnumerable<Property> Properties => _properties;

        public void AddProperty(Property property)
        {
            _properties.Add(property);
        }
    }
}
