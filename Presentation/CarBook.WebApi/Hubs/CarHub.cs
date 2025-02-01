using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;

namespace CarBook.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7127/api/Statistics/GetCarCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var carCount = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine($"Araba Sayısı: {carCount}"); // Konsola yazdır

                // Veriyi frontend'e gönder
                await Clients.All.SendAsync("ReceiveCarCount", carCount);
            }
            else
            {
                Console.WriteLine("API çağrısı başarısız oldu.");
            }
        }
    }
}