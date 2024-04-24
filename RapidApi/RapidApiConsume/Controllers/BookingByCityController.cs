using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class BookingByCityController : Controller
    {
        public async Task<IActionResult> Index(string cityId)
        {
            if (!string.IsNullOrEmpty(cityId))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-{cityId}&search_type=CITY&arrival_date=2024-04-23&departure_date=2024-05-25&adults=1&children_age=0%2C17&room_qty=1&page_number=1&languagecode=en-us&currency_code=AED"),
                    Headers =
                   {
        { "X-RapidAPI-Key", "346952ad39msh7c6fa779b7c03ccp1d1f3ajsnaf29fa8a1e4e" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
                  },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);

                    return View(values.data.hotels.ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-2092174&search_type=CITY&arrival_date=2024-04-23&departure_date=2024-05-25&adults=1&children_age=0%2C17&room_qty=1&page_number=1&languagecode=en-us&currency_code=AED"),
                    Headers =
    {
        { "X-RapidAPI-Key", "346952ad39msh7c6fa779b7c03ccp1d1f3ajsnaf29fa8a1e4e" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);

                    return View(values.data.hotels.ToList());
                }
            }
        }
    
           
            } 
            
        }
    
