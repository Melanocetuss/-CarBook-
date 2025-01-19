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
            var LocationId = TempData["locationId"];
            var PickUpDate = TempData["pickUpDate"];
            var DropOffDate = TempData["dropOffDate"];
            var PickUpTime = TempData["pickUpTime"];
            var DropOffTime = TempData["dropOffTime"];

            ViewBag.LocationId = LocationId;
            ViewBag.PickUpDate = PickUpDate;
            ViewBag.DropOffDate = DropOffDate;
            ViewBag.PickUpTime = PickUpTime;
            ViewBag.DropOffTime = DropOffTime;

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