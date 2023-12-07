﻿using HolidayDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HolidayDomain.Repositories
{
    public class EfPropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public EfPropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Property> GetAll()
        {
            return _context.Properties.AsNoTracking().ToList();
        }

        public IEnumerable<Property> GetAvailable(DateTime start, DateTime end)
        {
            return _context.Properties.AsNoTracking()
                .Where(p => p.BookedNights
                    .Select(n => n.Night)
                    .All(d => d <= start || d > end))
                .ToList();
        }

        public Property? GetById(int id)
        {
            return _context.Properties.AsNoTracking()
                .Include(p => p.BookedNights)
                .FirstOrDefault(p => p.Id == id);
        }

        public Property Add(Property property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
            return property;
        }

        public Property BookProperty(int propertyId, DateTime start, DateTime end)
        {
            var property = _context.Properties
                .Include(p => p.BookedNights)
                .First(p => p.Id == propertyId);

            for (var date = start.AddDays(1); date <= end; date = date.AddDays(1))
            {
                var bookedNight = new BookedNight
                {
                    Night = date
                };
                property.BookedNights.Add(bookedNight);
            }
            _context.SaveChanges();
            return property;
        }
    }
}
