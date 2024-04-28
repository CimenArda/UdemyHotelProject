﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _MessageCategoryService;

        public MessageCategoryController(IMessageCategoryService MessageCategoryService)
        {
            _MessageCategoryService = MessageCategoryService;
        }

        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var values = _MessageCategoryService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageCategory(int id)
        {
            var value = _MessageCategoryService.TGetbyId(id);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult AddMessageCategory(MessageCategory MessageCategory)
        {

            _MessageCategoryService.TInsert(MessageCategory);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessageCategory(int id)
        {
            var values = _MessageCategoryService.TGetbyId(id);

            _MessageCategoryService.TDelete(values);
            return Ok();

        }


        [HttpPut]
        public IActionResult UpdateMessageCategory(MessageCategory MessageCategory)
        {
            _MessageCategoryService.TUpdate(MessageCategory);

            return Ok();

        }
    }
}
