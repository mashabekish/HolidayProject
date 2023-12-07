using HolidayDomain.Entities;

namespace HolidayDomain.Repositories
{
    public interface IBookingRepository
    {
        Booking? MakeBooking(int propertyId, DateTime startDate, DateTime endDate, string userEmail, string billingAddress);
    }
}
