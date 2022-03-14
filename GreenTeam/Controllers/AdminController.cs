using GreenTeam.Implementations;
using GreenTeam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GreenTeam.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
       /* private readonly IUserService userService; */

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager/*, IUserService userService*/)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            /*this.userService = userService;*/ // TODO delete
        }

        // Get Garden/Index
        public IActionResult Index()
        {
            return View();
        }

        // Get Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // Post Admin/Create
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationRole role)
        {
            bool roleExist = await roleManager.RoleExistsAsync(role.RoleName);
            if (!roleExist)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));
            }
            return View();
        }

        // Get Admin/Userlist
        [HttpGet]
        public IActionResult ListUsers()
        {
            List<AppUser> appUsers = userManager.Users.ToList();
            return View(appUsers);
        }

        // Post Admin/Delete
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found"; 
                return View("NotFound");
            }
            else
            {
               var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }
    }
}