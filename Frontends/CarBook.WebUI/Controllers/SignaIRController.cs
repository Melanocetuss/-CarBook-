using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class SignaIRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
