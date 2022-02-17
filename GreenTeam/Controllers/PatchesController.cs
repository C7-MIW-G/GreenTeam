using Microsoft.AspNetCore.Mvc;
using GreenTeam.Models;
using GreenTeam.Services;
using Microsoft.EntityFrameworkCore;
using GreenTeam.Implementations;

namespace GreenTeam.Controllers
{
    public class PatchesController : Controller { 

        private readonly IPatchService patchService;
    
        public PatchesController(IPatchService PatchService)
        {
            this.patchService = PatchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get: Patches/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Patches/Create/[gardenid]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Crop, PatchName, GardenId")] Patch patch)
        {
            if (!ModelState.IsValid)
            {
                Patch returnedPatch = await patchService.AddPatch(patch);
                return RedirectToAction("Details", "Gardens", new { id = patch.GardenId });

            }
            return View(patch);
        }

        //GET: Patches/Edit/6
        public async Task<IActionResult> Edit(int id)
        {
            Patch returnedPatch = await patchService.FindById(id);
            return View(returnedPatch);
            
        }

        //POST: Patches/Edit/6
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Crop, PatchName, GardenId")] Patch patch)
        {
            if (id != patch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Patch returnedPatch = await patchService.EditPatch(patch);

                return RedirectToAction("Details", "Gardens", new { id = patch.GardenId });
            }
            return View(patch);
        }

        //Get: Patches/Delete/6
        public async Task<IActionResult> Delete(int id)
        {
            Patch patch = await patchService.FindById(id);

            if (patch == null)
            {
                return NotFound();
            }
            return View(patch);
        }

        //POST: Patches/Delete/6
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Patch patchToDelete = await patchService.DeletePatch(id);
            return RedirectToAction("Details", "Gardens", new { id = patchToDelete.GardenId });
        }
    }
}
