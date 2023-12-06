using HolidayDomain.Entities;

namespace HolidayDomain.Repositories
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> Properties { get; }
        void AddProperty(Property property);
    }
}
