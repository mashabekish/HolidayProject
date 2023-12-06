namespace HolidayDomain.Entities
{
    public class BookedNight
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public DateTime Night { get; set; }
    }
}
