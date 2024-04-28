using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _SendMessageService;

        public SendMessageController(ISendMessageService SendMessageService)
        {
            _SendMessageService = SendMessageService;
        }

        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values = _SendMessageService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var value = _SendMessageService.TGetbyId(id);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult AddSendMessage(SendMessage SendMessage)
        {

            _SendMessageService.TInsert(SendMessage);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var values = _SendMessageService.TGetbyId(id);

            _SendMessageService.TDelete(values);
            return Ok();

        }


        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage SendMessage)
        {
            _SendMessageService.TUpdate(SendMessage);

            return Ok();

        }

        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            return Ok(_SendMessageService.GetSendMessageCount());
        }
    }
}
