using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AdminDashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random(); //ProgressBar İçin Kullandım.
            var client = _httpClientFactory.CreateClient();

            #region CarCount
            var responseMessageCarCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetCarCount");
            if (responseMessageCarCount.IsSuccessStatusCode)
            {
                var carJsonData = await responseMessageCarCount.Content.ReadAsStringAsync();
                var carValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(carJsonData);

                ViewBag.carCount = carValues.CarCount;
                ViewBag.CarRandomNumber = random.Next(0, 101);
            }
            #endregion

            #region LocationCount
            var responseMessageLocationCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetLocationCount");
            if (responseMessageLocationCount.IsSuccessStatusCode)
            {
                var locationJsonData = await responseMessageLocationCount.Content.ReadAsStringAsync();
                var locationValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(locationJsonData);

                ViewBag.locationCount = locationValues.LocationCount;
                ViewBag.locationRandomNumber = random.Next(0, 101);
            }
            #endregion
                  
            #region BrandCount
            var responseMessageBrandCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetBrandCount");
            if (responseMessageBrandCount.IsSuccessStatusCode)
            {
                var brandJsonData = await responseMessageBrandCount.Content.ReadAsStringAsync();
                var brandValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(brandJsonData);

                ViewBag.brandCount = brandValues.BrandCount;
                ViewBag.brandRandomNumber = random.Next(0, 101);
            }
            #endregion

            #region AvgRentPriceForDaileyCount
            var responseMessageAvgRentPriceForDaileyCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetAvgRentPriceForDailey");
            if (responseMessageAvgRentPriceForDaileyCount.IsSuccessStatusCode)
            {
                var avgRentPriceForDaileyCountJsonData = await responseMessageAvgRentPriceForDaileyCount.Content.ReadAsStringAsync();
                var avgRentPriceForDaileyCountValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(avgRentPriceForDaileyCountJsonData);

                ViewBag.avgRentPriceForDaileyCount = avgRentPriceForDaileyCountValues.AvgRentPriceForDailey;
                ViewBag.avgRentPriceForDaileyCountRandomNumber = random.Next(0, 101);
            }
            #endregion

            return View();          
        }
    }
}