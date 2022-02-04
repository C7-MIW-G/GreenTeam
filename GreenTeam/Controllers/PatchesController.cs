using GreenTeam.Models;
using GreenTeam.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenTeam.Controllers
{
    public class PatchesController : Controller 
    { 

        private readonly IPatchService patchService;
    
        public PatchesController(IPatchService patchService)
        {
            this.patchService = patchService;
        }

        //GET: Patches/Index/6
        public async Task<IActionResult> Index(int Id)
        {
            List<Patch> patches = await patchService.FindByGardenId(Id);
            return View(patches);
        }

        //Get: Patches/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Patches/Create/[gardenid]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Crop,GardenId")] Patch patch)
        {
            if (!ModelState.IsValid)
            {
                Patch returnedPatch = await patchService.AddPatch(patch);
                return RedirectToAction("Index", new { id = patch.GardenId});

            }
            return View(patch);
        }
    }
}
