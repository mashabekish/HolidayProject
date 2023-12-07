using HolidayDomain.Entities;

namespace HolidayDomain.Repositories
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
        IEnumerable<Property> GetAvailable(DateTime start, DateTime end);
        Property? GetById(int id);
        Property Add(Property property);
        Property BookProperty(int propertyId, DateTime start, DateTime end);
        PropertyImage AddPropertyImage(int propertyId, string imageUrl);
    }
}
