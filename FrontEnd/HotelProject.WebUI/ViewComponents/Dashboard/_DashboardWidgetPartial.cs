using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("http://localhost:47401/api/DashboardWidget/StaffCount");
            var jsonData = await responsMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
            ViewBag.staffcount = jsonData;


            var client2 = _httpClientFactory.CreateClient();
            var responsMessage2 = await client2.GetAsync("http://localhost:47401/api/DashboardWidget/BookingCount");
            var jsonData2 = await responsMessage2.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
            ViewBag.bookingcount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responsMessage3 = await client3.GetAsync("http://localhost:47401/api/DashboardWidget/AppUserCount");
            var jsonData3 = await responsMessage3.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
            ViewBag.appusercount = jsonData3;


            var client4 = _httpClientFactory.CreateClient();
            var responsMessage4 = await client4.GetAsync("http://localhost:47401/api/DashboardWidget/RoomCount");
            var jsonData4 = await responsMessage4.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
            ViewBag.roomcount = jsonData4;



            return View();
        }
    }
}


