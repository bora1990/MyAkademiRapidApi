using Microsoft.AspNetCore.Mvc;
using MyAkademiRapidApi.Models;
using Newtonsoft.Json;

namespace MyAkademiRapidApi.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=USD&locale=en-gb"),  //base_currency propery olarak geldiğinden metotta bunu geçebiliriz. + ile Usd yerine ekleyebilriiz.
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
                var values=JsonConvert.DeserializeObject<ExchangeViewModel>(body);
            return View(values.exchange_rates.ToList());
            }
        }
    }
}
