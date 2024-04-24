﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Booking
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public string AdultCount { get; set; }

        public string ChildCount { get; set; }

        public string RoomCount { get; set; }

        public string SpecialRequest { get; set; }

        public string Description { get; set; }



        public string Status { get; set; }

    }
}