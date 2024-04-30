﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusChangeApproved(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeCancel(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "İptal Edildi";
            context.SaveChanges();
        }

        public void BookingStatusChangeHold(int id)
        {

            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Beklet";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
            var context = new Context();
            var values = context.Bookings.Count();

            return values;
        }

        public List<Booking> Last6Booking()
        {
            var context = new Context();
            var values = context.Bookings.Take(6).ToList();
            return values;
        }
    }
}
