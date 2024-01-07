using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using MyAkademiRapidApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Text;
using System.Text.Unicode;

namespace MyAkademiRapidApi.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=izmir&locale=tr"),
                Headers =
    {
        { "X-RapidAPI-Key", "01dfd38f50msh66c9795fc72071fp18d71bjsnf77af7a27463" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<SearchLocationViewModel>>(body);



                var language = value.FirstOrDefault().cc1;


                ViewBag.dil = language;
            }
            return View();
        }




        [HttpPost]

        public async Task<IActionResult> Otel(string sehir, string dil, string checkInDate, string checkOutDate, int adultNumber, int roomNumber)
        {
            var client = new HttpClient();


            if (!string.IsNullOrEmpty(sehir) && !string.IsNullOrEmpty(dil) && !string.IsNullOrEmpty(checkInDate) && !string.IsNullOrEmpty(checkOutDate) && roomNumber != 0 && adultNumber != 0)
            {
                DateTime tarih = DateTime.ParseExact(checkInDate, "d/M/yyyy", null);
                string newCheckIn = tarih.ToString("yyyy-dd-MM");



                DateTime tarih1 = DateTime.ParseExact(checkOutDate, "d/M/yyyy", null);
                string newCheckOut = tarih1.ToString("yyyy-dd-MM");


                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={sehir}&locale={dil}"),
                    Headers =
    {
      { "X-RapidAPI-Key", "01dfd38f50msh66c9795fc72071fp18d71bjsnf77af7a27463" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };

                string locationid;


                using (var response = await client.SendAsync(request))
                {

                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<List<SearchLocationViewModel>>(body);

                    locationid = value.FirstOrDefault().dest_id;
                }

                var request1 = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?room_number={roomNumber}&adults_number={adultNumber}&checkout_date={newCheckOut}&filter_by_currency=TRY&units=metric&locale=tr&checkin_date={newCheckIn}&dest_type=city&dest_id={locationid}&order_by=popularity&children_ages=5%2C0&children_number=2&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0"),
                    Headers =
    {
        { "X-RapidAPI-Key", "2ce6a48157msh92dd410e475d903p1ecdf8jsn707a1ffacec7" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response1 = await client.SendAsync(request1))
                {
                    response1.EnsureSuccessStatusCode();
                    var body1 = await response1.Content.ReadAsStringAsync();
                    var classData = JsonConvert.DeserializeObject<OtelVeriViewModel>(body1);

                    ViewBag.data = classData.Results;

                    return View();

                }


            }
          return  RedirectToAction("Index");
        }


    }

}