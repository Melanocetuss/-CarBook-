using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminDashboardComponents
{
    public class _AdminDashboardFirstChartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
