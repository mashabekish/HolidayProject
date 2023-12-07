namespace HolidayWebApplication.Models
{
    public class AddImageModel
    {
        public int PropertyId { get; set; }
        public IFormFile Image { get; set; }
    }
}
