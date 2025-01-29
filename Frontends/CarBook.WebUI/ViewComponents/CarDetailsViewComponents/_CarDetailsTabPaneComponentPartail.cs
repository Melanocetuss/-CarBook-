using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarDetailsViewComponents
{
    public class _CarDetailsTabPaneComponentPartail : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
