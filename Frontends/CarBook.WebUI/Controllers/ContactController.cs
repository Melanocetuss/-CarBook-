using CarBook.Dto.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "İletişim";
            ViewBag.v2 = "Bizimle İletişime Geçin";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            createContactDto.SendDate = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7127/api/Contacts",stringContent);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();
        }
    }
}