using Microsoft.AspNetCore.Mvc;

namespace HolidayWebApplication.ViewComponents
{
    public class FilterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
