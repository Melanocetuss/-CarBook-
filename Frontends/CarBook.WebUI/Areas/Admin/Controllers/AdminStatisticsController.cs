using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        [Route("Index")]
        public async Task<IActionResult> Index()
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

            #region AuthorCount
            var responseMessageAuthorCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetAuthorCount");
            if (responseMessageAuthorCount.IsSuccessStatusCode)
            {
                var authorJsonData = await responseMessageAuthorCount.Content.ReadAsStringAsync();
                var authorValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(authorJsonData);

                ViewBag.authorCount = authorValues.AuthorCount;
                ViewBag.authorRandomNumber = random.Next(0, 101);
            }
            #endregion

            #region BlogCount
            var responseMessageBlogCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetBlogCount");
            if (responseMessageBlogCount.IsSuccessStatusCode)
            {
                var blogJsonData = await responseMessageBlogCount.Content.ReadAsStringAsync();
                var blogValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(blogJsonData);

                ViewBag.blogCount = blogValues.BlogCount;
                ViewBag.blogRandomNumber = random.Next(0, 101);
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

            #region AvgRentPriceForWeeklyCount
            var responseMessageAvgRentPriceForWeeklyCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessageAvgRentPriceForWeeklyCount.IsSuccessStatusCode)
            {
                var avgRentPriceForWeeklyCountJsonData = await responseMessageAvgRentPriceForWeeklyCount.Content.ReadAsStringAsync();
                var avgRentPriceForWeeklyCountValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(avgRentPriceForWeeklyCountJsonData);

                ViewBag.avgRentPriceForWeeklyCount = avgRentPriceForWeeklyCountValues.AvgRentPriceForWeekly;
                ViewBag.avgRentPriceForWeeklyCountRandomNumber = random.Next(0, 101);
            }
            #endregion

            #region AvgRentPriceForMonthlyCount
            var responseMessageAvgRentPriceForMonthlyCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessageAvgRentPriceForMonthlyCount.IsSuccessStatusCode)
            {
                var avgRentPriceForMonthlyCountJsonData = await responseMessageAvgRentPriceForMonthlyCount.Content.ReadAsStringAsync();
                var avgRentPriceForMonthlyCountValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(avgRentPriceForMonthlyCountJsonData);

                ViewBag.avgRentPriceForMonthlyCount = avgRentPriceForMonthlyCountValues.AvgRentPriceForMonthly;
                ViewBag.avgRentPriceForMonthlyCountRandomNumber = random.Next(0, 101);
            }
            #endregion

            return View();
        }
    }
}
