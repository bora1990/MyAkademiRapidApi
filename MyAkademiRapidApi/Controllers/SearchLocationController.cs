using Microsoft.AspNetCore.Mvc;
using MyAkademiRapidApi.Models;
using Newtonsoft.Json;

namespace MyAkademiRapidApi.Controllers
{
    public class SearchLocationController : Controller
    {
        public async Task<IActionResult> Index(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={city}&locale=en-gb"),
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
                    var value=JsonConvert.DeserializeObject<List<SearchLocationViewModel>>(body);

                    return View(value.ToList());
                }
            }
            else
            {

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name=izmir&locale=en-gb"),
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
                    var value = JsonConvert.DeserializeObject<List<SearchLocationViewModel>>(body);

                    return View(value.ToList());
                }

            }
        }
    }
}
