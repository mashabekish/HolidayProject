﻿namespace HolidayWebApplication.Models
{
    public class CreateBookingModel
    {
        public int PropertyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
