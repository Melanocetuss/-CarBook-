using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
