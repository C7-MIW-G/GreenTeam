using Microsoft.AspNetCore.Mvc;
using GreenTeam.Models;
using GreenTeam.Implementations;
using System.Security.Claims;
using GreenTeam.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GreenTeam.Controllers
{
    public class PatchesController : Controller
    {

        private readonly IPatchService patchService;
        private readonly IUserService userService;

        public PatchesController(IPatchService PatchService, IUserService userService)
        {
            this.patchService = PatchService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Patches/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            PatchVM patchVM = await patchService.GetVMById(id);

            if (patchVM == null)
            {
                return NotFound();
            }

            return View(patchVM);
        }

        //Get: Patches/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        //POST: Patches/Create/[gardenid]
        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> Create([Bind("Id, Crop, PatchName, GardenId")] Patch patch)
        {
            if (!ModelState.IsValid)
            {
                int gardenId = patch.GardenId;
                bool isCreateAllowed = await userService.IsManager(gardenId);

                if (isCreateAllowed)
                {
                    await patchService.AddPatch(patch);
                    return RedirectToAction("Details", "Gardens", new { id = patch.GardenId });
                }
            }
            return Unauthorized();
        }

        //GET: Patches/Edit/6
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            int gardenId = await patchService.GetGardenIdByPatchId(id);
            bool isEditAllowed = await userService.IsManager(gardenId);

            if (isEditAllowed)
            {
                PatchVM patchVM = await patchService.GetVMById(id);
                return View(patchVM);
            }

            return Unauthorized();

        }

        //POST: Patches/Edit/6
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Crop, PatchName, GardenId")] Patch patch)
        {
            int gardenId = patch.GardenId;
            bool isEditAllowed = await userService.IsManager(gardenId);
            if (!isEditAllowed)
            {
                return Unauthorized();
            }

            if (id != patch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await patchService.EditPatch(patch);

                return RedirectToAction("Details", "Gardens", new { id = patch.GardenId });
            }
            PatchVM patchVM = await patchService.GetVMById(id);
            return View(patchVM);
        }

        //Get: Patches/Delete/6
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            int gardenId = await patchService.GetGardenIdByPatchId(id);
            bool isEditAllowed = await userService.IsManager(gardenId);

            if (!isEditAllowed)
            {
                return Unauthorized();
            }
            PatchVM patchVM = await patchService.GetVMById(id);

            if (patchVM == null)
            {
                return NotFound();
            }
            return View(patchVM);
        }

        //POST: Patches/Delete/6
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int gardenId = await patchService.GetGardenIdByPatchId(id);
            bool isEditAllowed = await userService.IsManager(gardenId);
            if (!isEditAllowed)
            {
                return Unauthorized();
            }

            Patch patchToDelete = await patchService.DeletePatch(id);
            return RedirectToAction("Details", "Gardens", new { id = patchToDelete.GardenId });

        }
    }
}
