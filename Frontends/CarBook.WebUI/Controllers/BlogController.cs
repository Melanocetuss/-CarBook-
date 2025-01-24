using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglarımız";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7127/api/Blogs/GetAllBlogWithAuthors");

            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı Ve Yorumlar";
            ViewBag.blogid = id;          
            return View();
        }
    }
}
