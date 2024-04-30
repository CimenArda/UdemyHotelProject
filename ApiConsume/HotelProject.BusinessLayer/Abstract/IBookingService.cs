using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void BookingStatusChangeApproved(int id);

        void BookingStatusChangeHold(int id);

        void BookingStatusChangeCancel(int id);

        int GetBookingCount();


        List<Booking> TLast6Booking();

    }

}
