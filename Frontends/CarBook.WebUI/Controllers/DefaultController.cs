using CarBook.Dto.BrandDtos;
using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.LocationValues = await GetLocationSelectListAsync();
            return View();
        }

        [HttpPost]
        public IActionResult Index(string locationId, string pickUpDate, string dropOffDate, string pickUpTime, string dropOffTime)
        {
            TempData["locationId"] = locationId;
            TempData["pickUpDate"] = pickUpDate;
            TempData["dropOffDate"] = dropOffDate;
            TempData["pickUpTime"] = pickUpTime;
            TempData["dropOffTime"] = dropOffTime;
            return RedirectToAction("Index", "RentACarList");
        }

        private async Task<List<SelectListItem>> GetLocationSelectListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return new List<SelectListItem>(); // Eğer token yoksa boş liste döndür
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await client.GetAsync("https://localhost:7127/api/Locations");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                return values?.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.LocationID.ToString()
                }).ToList() ?? new List<SelectListItem>();
            }

            return new List<SelectListItem>();
        }
    }
}