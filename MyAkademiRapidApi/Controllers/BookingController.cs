using Microsoft.AspNetCore.Mvc;
using MyAkademiRapidApi.Models;
using Newtonsoft.Json;

namespace MyAkademiRapidApi.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index(string lokasyon)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/search?units=metric&dest_id={lokasyon}&dest_type=city&room_number=1&checkin_date=2024-05-19&order_by=popularity&locale=en-gb&adults_number=2&checkout_date=2024-05-20&filter_by_currency=AED&page_number=0&children_number=2&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&include_adjacency=true"),
                Headers =
    {
        { "X-RapidAPI-Key", "fcc917b06amshef0279bc7db36f7p13a42djsnea390bd6c306" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                return View(values.result.ToList());
            }
        }
    }
}
