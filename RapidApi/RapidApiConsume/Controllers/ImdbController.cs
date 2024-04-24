using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using RapidApiConsume.Models;
using Newtonsoft.Json;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> movieViewModels = new List<ApiMovieViewModel>();



            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "ff6bd20e1emshe43dd1aa8d4e77cp1185e1jsnb9d0d86109a6" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                movieViewModels=JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body); 
                return View(movieViewModels);
            
            }

        }
    }
}
