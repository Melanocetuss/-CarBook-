using CarBook.Dto.BlogDtos;
using CarBook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailTagCloudComponentPartail : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogDetailTagCloudComponentPartail(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.Id = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/TagClouds/GetTagCloudByBlog?id="+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGetByBlogIdTagCloud>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
