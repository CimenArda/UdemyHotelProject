using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using HotelProject.WebUI.Dtos.FollowersDto;
using Newtonsoft.Json;
using static HotelProject.WebUI.Dtos.FollowersDto.ResultTwitterFollowersDto.Data;
using Org.BouncyCastle.Asn1.Ocsp;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCount :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/murattycedag"),
                Headers =
    {
        { "X-RapidAPI-Key", "346952ad39msh7c6fa779b7c03ccp1d1f3ajsnaf29fa8a1e4e" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowerDto resultInstagramFollowerDtos =JsonConvert.DeserializeObject<ResultInstagramFollowerDto>(body);
                ViewBag.v1 = resultInstagramFollowerDtos.followers;
                ViewBag.v2 = resultInstagramFollowerDtos.following;
               
              
            }


            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=murattyucedag"),
                Headers =
    {
        { "X-RapidAPI-Key", "346952ad39msh7c6fa779b7c03ccp1d1f3ajsnaf29fa8a1e4e" },
        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                var  user_Info = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                ViewBag.t1 = user_Info.data.user_info.friends_count;
                ViewBag.t2 = user_Info.data.user_info.followers_count;

            }

       
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=www.linkedin.com%2Fin%2Farda-cimen&include_skills=false"),
                Headers =
    {
        { "X-RapidAPI-Key", "346952ad39msh7c6fa779b7c03ccp1d1f3ajsnaf29fa8a1e4e" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
               var data_info = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body3);
                ViewBag.l1 = data_info.data.connections_count;
                ViewBag.l2 = data_info.data.followers_count;


            }

            return View();
        }
           


    }
}
