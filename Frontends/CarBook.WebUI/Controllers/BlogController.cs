using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.blogid = id;
            return PartialView();
        }

        [HttpPost]        
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto) 
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7127/api/Comments", stringContent);

            if (responseMessage.IsSuccessStatusCode) 
            {
                TempData["SuccessMessage"] = "Yorum başarıyla alındı!";
                return RedirectToAction("BlogDetails", "Blog", new { id = createCommentDto.BlogID });
            }
            TempData["ErrorMessage"] = "Yorum oluşturulurken bir hata oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("BlogDetails", "Blog", new { id = createCommentDto.BlogID });
        }
    }
}
