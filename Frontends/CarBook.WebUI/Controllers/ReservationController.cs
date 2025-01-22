using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Rezervasyon";
            ViewBag.v2 = "Rezervasyonunuzu Tamamlayın.";

            ViewBag.LocationValues = await GetLocationSelectListAsync();         
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7127/api/Reservations", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Rezervasyonunuz başarıyla alındı!";
                return RedirectToAction("Index", "Default");
            }

            TempData["ErrorMessage"] = "Rezervasyon oluşturulurken bir hata oluştu. Lütfen tekrar deneyin.";
            return View();
        }
        private async Task<List<SelectListItem>> GetLocationSelectListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7127/api/Locations");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return values.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.LocationID.ToString()
                }).ToList();
            }

            return new List<SelectListItem>();
        }
    }
}
