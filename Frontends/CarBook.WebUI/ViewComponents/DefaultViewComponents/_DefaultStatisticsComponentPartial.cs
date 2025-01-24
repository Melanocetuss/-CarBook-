using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region CarCount
            var responseMessageCarCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetCarCount");
            if (responseMessageCarCount.IsSuccessStatusCode)
            {
                var carJsonData = await responseMessageCarCount.Content.ReadAsStringAsync();
                var carValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(carJsonData);

                ViewBag.carCount = carValues.CarCount;
            }
            #endregion

            #region AvgRentPriceForDaileyCount
            var responseMessageAvgRentPriceForDaileyCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetAvgRentPriceForDailey");
            if (responseMessageAvgRentPriceForDaileyCount.IsSuccessStatusCode)
            {
                var avgRentPriceForDaileyCountJsonData = await responseMessageAvgRentPriceForDaileyCount.Content.ReadAsStringAsync();
                var avgRentPriceForDaileyCountValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(avgRentPriceForDaileyCountJsonData);

                ViewBag.avgRentPriceForDaileyCount = avgRentPriceForDaileyCountValues.AvgRentPriceForDailey;
            }
            #endregion

            #region AvgRentPriceForWeeklyCount
            var responseMessageAvgRentPriceForWeeklyCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessageAvgRentPriceForWeeklyCount.IsSuccessStatusCode)
            {
                var avgRentPriceForWeeklyCountJsonData = await responseMessageAvgRentPriceForWeeklyCount.Content.ReadAsStringAsync();
                var avgRentPriceForWeeklyCountValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(avgRentPriceForWeeklyCountJsonData);

                ViewBag.avgRentPriceForWeeklyCount = avgRentPriceForWeeklyCountValues.AvgRentPriceForWeekly;
            }
            #endregion

            #region BlogCount
            var responseMessageBlogCount = await client.GetAsync("https://localhost:7127/api/Statistics/GetBlogCount");
            if (responseMessageBlogCount.IsSuccessStatusCode)
            {
                var blogJsonData = await responseMessageBlogCount.Content.ReadAsStringAsync();
                var blogValues = JsonConvert.DeserializeObject<ResultStatisticsDto>(blogJsonData);

                ViewBag.blogCount = blogValues.BlogCount;
            }
            #endregion

            return View();
        }
    }
}