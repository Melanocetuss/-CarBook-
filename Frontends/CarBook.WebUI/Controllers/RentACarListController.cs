using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Uygun Araçlar";
            ViewBag.v2 = "Aracınızı Seçin Ve Hemen Kiralayın";

            var LocationId = TempData["locationId"];
            ViewBag.LocationId = LocationId;

            var client =  _httpClientFactory.CreateClient();          
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/RentACars?LocationID={LocationId}&Available=true");

            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                
                return View(values);
            }

            return View();
        }
    }
}