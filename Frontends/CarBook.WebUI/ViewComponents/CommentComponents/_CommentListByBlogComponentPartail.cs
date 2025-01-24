using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CommentComponents
{
    public class _CommentListByBlogComponentPartail : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CommentListByBlogComponentPartail(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/Comments/GetCommentsByBlogId?id={id}");

            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}