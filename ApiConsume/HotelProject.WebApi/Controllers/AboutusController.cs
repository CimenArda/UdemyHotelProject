using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutusController : ControllerBase
    {
        private readonly IAboutusService _AboutusService;

        public AboutusController(IAboutusService AboutusAboutus)
        {
            _AboutusService = AboutusAboutus;
        }

        [HttpGet]
        public IActionResult AboutusList()
        {
            var values = _AboutusService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetAboutus(int id)
        {
            var value = _AboutusService.TGetbyId(id);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult AddAboutus(AboutUs Aboutus)
        {

            _AboutusService.TInsert(Aboutus);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAboutus(int id)
        {
            var values = _AboutusService.TGetbyId(id);

            _AboutusService.TDelete(values);
            return Ok();

        }


        [HttpPut]
        public IActionResult UpdateAboutus(AboutUs Aboutus)
        {
            _AboutusService.TUpdate(Aboutus);

            return Ok();

        }
    }
}
