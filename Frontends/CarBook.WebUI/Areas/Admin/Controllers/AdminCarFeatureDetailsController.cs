using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetails")]
    public class AdminCarFeatureDetailsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarFeatureDetailsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/CarFeatures?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [Route("Index/{id}")]
        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            foreach (var item in resultCarFeatureByCarIdDto) 
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7127/api/CarFeatures/CarFeatureAvailableChangeToTrue?id={item.CarFeatureID}");
                }

                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7127/api/CarFeatures/CarFeatureAvailableChangeToFalse?id={item.CarFeatureID}");
                }
            }
            return RedirectToAction("Index","AdminCar");
            
        }

        [Route("CreateFeatureByCar")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7127/api/Features");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
