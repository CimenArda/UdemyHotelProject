using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _SubscribeService;

        public SubscribeController(ISubscribeService SubscribeService)
        {
            _SubscribeService = SubscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _SubscribeService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var value = _SubscribeService.TGetbyId(id);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult AddSubscribe(Subscribe Subscribe)
        {

            _SubscribeService.TInsert(Subscribe);
            return Ok();

        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _SubscribeService.TGetbyId(id);

            _SubscribeService.TDelete(values);
            return Ok();

        }


        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe Subscribe)
        {
            _SubscribeService.TUpdate(Subscribe);

            return Ok();

        }
    }
}
