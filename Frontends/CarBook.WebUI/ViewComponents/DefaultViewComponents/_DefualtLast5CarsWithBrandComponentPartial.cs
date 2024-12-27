using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefualtLast5CarsWithBrandComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefualtLast5CarsWithBrandComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7127/api/Cars/GetLast5CarsWithBrand");

            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrand>>(jsonData);
                
                return View(values);
            }

            return View();
        }
    }
}
