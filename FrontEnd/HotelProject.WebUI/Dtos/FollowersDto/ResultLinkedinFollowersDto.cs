﻿namespace HotelProject.WebUI.Dtos.FollowersDto
{
    public class ResultLinkedinFollowersDto
    {


      
            public Data data { get; set; }
            public string message { get; set; }
      

        public class Data
        {
         
            public int connections_count { get; set; }

            public int followers_count { get; set; }
          
        }

 

    }
}
