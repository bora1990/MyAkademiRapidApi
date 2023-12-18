using Microsoft.AspNetCore.Mvc;
using MyAkademiRapidApi.Models;
using Newtonsoft.Json;


namespace MyAkademiRapidApi.Controllers
{
    public class MoviewSeriesController : Controller
    {

        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "fcc917b06amshef0279bc7db36f7p13a42djsnea390bd6c306" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<SeriesViewModel>>(body);   //bir dizinin elemanları şeklinde geliyor . [{},{},....]
                return View(values);
            }
          
        }
    }
}
