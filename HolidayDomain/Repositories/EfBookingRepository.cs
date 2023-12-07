using HolidayDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HolidayDomain.Repositories
{
    public class EfBookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public EfBookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Booking? MakeBooking(int propertyId, DateTime startDate, DateTime endDate, string userEmail, string billingAddress)
        {
            var property = _context.Properties
                .Include(p => p.BookedNights)
                .FirstOrDefault(p => p.Id == propertyId);

            if (property == null || !IsPropertyAvailable(property, startDate, endDate))
                return null;

            for (var date = startDate.AddDays(1); date <= endDate; date = date.AddDays(1))
            {
                var bookedNight = new BookedNight
                {
                    Night = date
                };
                property.BookedNights.Add(bookedNight);
            }

            var booking = new Booking
            {
                PropertyId = propertyId,
                StartDate = startDate,
                EndDate = endDate,
                CostPerNight = property.CostPerNight,
                //UserId = UserId,
                UserEmail = userEmail,
                BillingAddress = billingAddress
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        private static bool IsPropertyAvailable(Property property, DateTime startDate, DateTime endDate)
        {
            return property.BookedNights
                .Select(n => n.Night)
                .All(d => d <= startDate || d > endDate);
        }
    }
}
