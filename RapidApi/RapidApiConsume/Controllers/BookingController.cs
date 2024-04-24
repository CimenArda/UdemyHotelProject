using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-2092174&search_type=CITY&arrival_date=2024-04-23&departure_date=2024-07-05&adults=1&children_age=0%2C17&room_qty=1&page_number=1&languagecode=en-us&currency_code=AED"),
                Headers =
    {
        { "X-RapidAPI-Key", "ff6bd20e1emshe43dd1aa8d4e77cp1185e1jsnb9d0d86109a6" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values =JsonConvert.DeserializeObject<BookingApiViewModel>(body);

                    return View(values.data.hotels.ToList());

            }
        }
    }
}
