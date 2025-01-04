using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
