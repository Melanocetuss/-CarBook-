using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            
            var countCommentResponseMessage = await client.GetAsync($"https://localhost:7127/api/Comments/GetCountCommentByBlog?id=" + id);
            var countCommentJsonData = await countCommentResponseMessage.Content.ReadAsStringAsync();
            ViewBag.countComment = countCommentJsonData;
            
            ViewBag.Id = id;           
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/Blogs/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultGetBlogById>(jsonData);
                return View(values);
            }
            
            return View();
        }       
    }
}
