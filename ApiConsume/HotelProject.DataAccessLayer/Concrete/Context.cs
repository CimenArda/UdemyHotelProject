﻿using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context :IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ARDACIMEN\\SQLEXPRESS;initial catalog=HotelProjectApiDb; integrated security=true;");

            base.OnConfiguring(optionsBuilder);
        }

   

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Subscribe>  Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }


        public DbSet<AboutUs> AboutUs  { get; set; }


        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }


        public DbSet<MessageCategory> messageCategories { get; set; }
        public DbSet<WorkLocation> workLocations { get; set; }



    }
}
