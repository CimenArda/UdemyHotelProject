using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void BookingStatusChangeApproved(int id)
        {
           _bookingDal.BookingStatusChangeApproved(id);
        }

        public void BookingStatusChangeCancel(int id)
        {
           _bookingDal.BookingStatusChangeCancel(id);
        }

        public void BookingStatusChangeHold(int id)
        {
            _bookingDal.BookingStatusChangeHold(id);
        }

        public int GetBookingCount()
        {
           return _bookingDal.GetBookingCount();
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public Booking TGetbyId(int id)
        {
          return  _bookingDal.GetbyId(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public void TInsert(Booking t)
        {
            _bookingDal.Insert(t);
        }

        public List<Booking> TLast6Booking()
        {
           return _bookingDal.Last6Booking();
        }

        public void TUpdate(Booking t)
        {
           _bookingDal.Update(t);
        }
    }
}
