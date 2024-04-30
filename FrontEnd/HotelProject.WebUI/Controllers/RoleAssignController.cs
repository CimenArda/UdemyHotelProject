using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
         
                var values = _userManager.Users.ToList();


                return View(values);
            
        }


        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.First(x => x.Id == id);
            TempData["userid"] = user.Id;
            var roles =_roleManager.Roles.ToList();
            var UserRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();

            foreach(var item in roles)
            {
                RoleAssignViewModel roleAssignViewModel = new();
                roleAssignViewModel.RoleID = item.Id;
                roleAssignViewModel.RoleName = item.Name;
                roleAssignViewModel.RoleExist = UserRoles.Contains(item.Name);
                roleAssignViewModels.Add(roleAssignViewModel);
            }
            return View(roleAssignViewModels);

        }


        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModel)
        {


            var userID = (int)TempData["userid"];
            var user =_userManager.Users.First(x=>x.Id == userID);
            foreach(var item in roleAssignViewModel) 
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");

        }
    }
}
