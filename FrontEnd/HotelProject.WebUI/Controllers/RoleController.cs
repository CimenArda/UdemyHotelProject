using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
        {
            AppRole app = new AppRole()
            {
                Name = addRoleViewModel.RoleName
            };

            var result = await  _roleManager.CreateAsync(app);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async  Task<IActionResult> DeleteRole(int id)
        {
            var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);

            await _roleManager.DeleteAsync(value);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var value = await _roleManager.Roles.FirstAsync(x => x.Id == id);

            UpdateRoleViewModel app = new UpdateRoleViewModel()
            {
                Id = value.Id,
                RoleName = value.Name
            };


            return View(app);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var value = _roleManager.Roles.FirstOrDefault(x=>x.Id == updateRoleViewModel.Id);
            value.Name= updateRoleViewModel.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");



        }
    }

    }

