using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingService _BookingService;

        public BookingController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _BookingService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _BookingService.TGetbyId(id);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult AddBooking(Booking Booking)
        {

            _BookingService.TInsert(Booking);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _BookingService.TGetbyId(id);

            _BookingService.TDelete(values);
            return Ok();

        }


        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking Booking)
        {
            _BookingService.TUpdate(Booking);

            return Ok();

        }


        [HttpPut("UpdateReservationStatus")]
        public IActionResult UpdateReservationStatus(int id)
        {
            _BookingService.BookingStatusChangeApproved(id);
            return Ok();

        }
    }
}
