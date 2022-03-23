using GreenTeam.Implementations;
using GreenTeam.Models;
using GreenTeam.ViewModels;
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
        private readonly IGardenService gardenService;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IGardenService gardenService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.gardenService = gardenService;
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

        //Get Admin/GardenList
        [HttpGet]
        public async Task<IActionResult> ListGardens()
        {
            List<GardenVM> gardens = await gardenService.GetAllGardenVMs();

            return View(gardens);
        }

        [HttpPost]
        //Post Admin/DeleteGarden
        public async Task<IActionResult> DeleteGarden(int id)
        {
            Garden garden = await gardenService.FindById(id);

            if (garden == null)
            {
                return View("NotFound");
            }
            await gardenService.DeleteGarden(id);

            return RedirectToAction("ListGardens");
        }

        // Get Admin/Userlist
        [HttpGet]
        public IActionResult ListUsers()
        {
            List<AppUser> appUsers = userManager.Users.ToList();
            appUsers.Sort();
            return View(appUsers);
        }

        // Post Admin/DeleteUser
        [HttpPost]
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