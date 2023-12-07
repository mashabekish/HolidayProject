using HolidayDomain.Entities;

namespace HolidayDomain.Repositories
{
    public interface IBookingRepository
    {
        Booking? MakeBooking(Booking booking);
        IEnumerable<Booking> GetBookingsByUser(string? userId);
    }
}
