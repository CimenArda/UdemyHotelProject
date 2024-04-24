using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RapidApiConsume.Models;
using Newtonsoft.Json;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async  Task<IActionResult> Index(string cityname)
        {


            if (!string.IsNullOrEmpty(cityname))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={cityname}"),
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
                    var model = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel>(body);
                    return View(model.data.Take(1).ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query=Ist"),
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
                    var model = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel>(body);
                    return View(model.data.Take(1).ToList());
                }
            }

        }

        }
    }

