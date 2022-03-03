using GreenTeam.Implementations;
using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenTeam.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        // GET: Gardens/Search
        [Authorize]
        public IActionResult Search(int Id)
        {
            return View();
        }

        // POST: Gardens/Search
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([Bind("Email, GardenId")] SearchUserVM search)
        {
            if (ModelState.IsValid)
            {
                AppUserVM foundUser = await userService.GetAppUserVMByEmail(search.Email);

                if (foundUser != null)
                {
                    await userService.AssignMemberToGarden(foundUser, search.GardenId);                                    
                }

                return RedirectToAction("Details", "Gardens", new { id = search.GardenId });

            }


            return View();

        }
    }
}
