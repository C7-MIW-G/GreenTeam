using GreenTeam.Implementations;
using GreenTeam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Search(int id)
        {
            bool isManager = await userService.IsManager(id);
            if (!isManager)
            {
                return View("AccessDeniedError");
            }
            return View();
        }

        // POST: Gardens/Search
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([Bind("Email, GardenId")] SearchUserVM search)
        {
            bool isManager = await userService.IsManager(search.GardenId);
            if (!isManager)
            {
                return View("AccessDeniedError");
            }

            if (ModelState.IsValid)
            {
                AppUserVM foundUser = await userService.GetAppUserVMByEmail(search.Email);
                if (foundUser == null)
                {
                    search.ConfirmationMessage = "This user does not exist";
                    return View(search);
                }

                try
                {
                    await userService.AssignMemberToGarden(foundUser, search.GardenId);
                }
                catch (DbUpdateException e)
                {
                    if (e.InnerException.Message.Contains("Violation of PRIMARY KEY"))
                    {
                        search.ConfirmationMessage = "This user is already a member of the garden";
                        return View(search);
                    }
                }
                return RedirectToAction("Details", "Gardens", new { id = search.GardenId });
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> RemoveMemberFromGarden(string id)
        {
            string[] emailWithGardenId = id.Split('+');
            string email = emailWithGardenId[0];
            int gardenId = int.Parse(emailWithGardenId[1]);
            bool authorized = await userService.IsManager(gardenId);

            if (authorized)
            {
                await userService.RemoveMemberFromGarden(email, gardenId);

                return RedirectToAction("Details", "Gardens", new { id = gardenId });                
            }

            return RedirectToAction("Details", "Gardens", new { id = gardenId });

        }
    }
}
