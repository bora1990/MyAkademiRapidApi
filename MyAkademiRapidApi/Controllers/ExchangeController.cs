using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyAkademiRapidApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MyAkademiRapidApi.Controllers
{
    public class ExchangeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {

          
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=USD&locale=en-gb"),  //base_currency propery olarak geldiğinden metotta bunu geçebiliriz. + ile Usd yerine ekleyebilriiz.
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
                    var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                ViewBag.v = new List<SelectListItem>(from x in values.exchange_rates.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.currency,
                                                         Value = x.currency.ToString()
                                                     }).ToList();
              

                    return View(values.exchange_rates.ToList());
                }
            
        
        }
        [HttpPost]
        public async Task<IActionResult> Index(string kur)
        {

            if (!string.IsNullOrEmpty(kur))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency={kur}&locale=en-gb"),  //base_currency propery olarak geldiğinden metotta bunu geçebiliriz. + ile Usd yerine ekleyebilriiz.
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
                    var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);

                    ViewBag.v = new List<SelectListItem>(from x in values.exchange_rates.ToList()
                                                         select new SelectListItem
                                                         {
                                                             Text = x.currency,
                                                             Value = x.currency.ToString()
                                                         }).ToList();

                    return View(values.exchange_rates.ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=USD&locale=en-gb"),  //base_currency propery olarak geldiğinden metotta bunu geçebiliriz. + ile Usd yerine ekleyebilriiz.
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
                    var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                    ViewBag.v = new List<SelectListItem>(from x in values.exchange_rates.ToList()
                                                         select new SelectListItem
                                                         {
                                                             Text = x.currency,
                                                             Value = x.currency.ToString()
                                                         }).ToList();

                    return View(values.exchange_rates.ToList());
                }
            }
        }
    }
}

