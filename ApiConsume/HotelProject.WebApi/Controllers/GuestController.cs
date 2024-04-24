using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _GuestService;

        public GuestController(IGuestService GuestService)
        {
            _GuestService = GuestService;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _GuestService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var value = _GuestService.TGetbyId(id);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult AddGuest(Guest Guest)
        {

            _GuestService.TInsert(Guest);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var values = _GuestService.TGetbyId(id);

            _GuestService.TDelete(values);
            return Ok();

        }


        [HttpPut]
        public IActionResult UpdateGuest(Guest Guest)
        {
            _GuestService.TUpdate(Guest);

            return Ok();

        }

    }
}
