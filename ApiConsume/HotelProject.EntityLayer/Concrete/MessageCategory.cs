﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class MessageCategory
    {
        public int MessageCategoryID { get; set; }

        public string CategoryName { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
