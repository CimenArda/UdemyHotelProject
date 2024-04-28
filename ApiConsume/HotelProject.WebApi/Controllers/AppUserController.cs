using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {

        private readonly IAppUserService _AppUserService;

        public AppUserController(IAppUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }


        [HttpGet("[action]")]
        public IActionResult UserListWithWorkLocation()
        {
            //var values =_AppUserService.TUserListWithWorkLocation();
            Context context = new Context();
            var values = context.Users.Include(x => x.WorkLocation).Select(y => new AppUserWorkLocationViewModel
            { Name = y.Name,
              SurName = y.Surname,
              WorkLocationID = y.WorkLocationID,
              WorkLocationName=y.WorkLocation.WorkLocationName
            
            }).ToList();
            return Ok(values);
        }

        [HttpGet("[action]")]
        public IActionResult AppUserList()
        {
            var values = _AppUserService.TGetList();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public IActionResult GetAppUser(int id)
        {
            var value = _AppUserService.TGetbyId(id);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult AddAppUser(AppUser AppUser)
        {

            _AppUserService.TInsert(AppUser);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppUser(int id)
        {
            var values = _AppUserService.TGetbyId(id);

            _AppUserService.TDelete(values);
            return Ok();

        }


        [HttpPut]
        public IActionResult UpdateAppUser(AppUser AppUser)
        {
            _AppUserService.TUpdate(AppUser);

            return Ok();

        }
    }
}
