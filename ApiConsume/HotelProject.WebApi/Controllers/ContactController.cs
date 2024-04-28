using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _ContactService;

        public ContactController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _ContactService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _ContactService.TGetbyId(id);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult AddContact(Contact Contact)
        {
            Contact.Date =Convert.ToDateTime(DateTime.Now.ToString());  


            _ContactService.TInsert(Contact);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var values = _ContactService.TGetbyId(id);

            _ContactService.TDelete(values);
            return Ok();

        }


        [HttpPut("UpdateContact")]
        public IActionResult UpdateContact(Contact Contact)
        {
            _ContactService.TUpdate(Contact);

            return Ok();

        }

        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            return  Ok(_ContactService.TGetContactCount());
        }
      
    }
}
