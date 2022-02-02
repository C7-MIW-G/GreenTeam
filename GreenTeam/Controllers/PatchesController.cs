#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreenTeam.Data;
using GreenTeam.Models;
using GreenTeam.Services;

namespace GreenTeam.Controllers
{
    public class PatchesController : Controller
    {
                                                                
        private readonly IPatchService patchService;
        private readonly IGardenService gardenService;

        public PatchesController(IPatchService patchService, IGardenService gardenService)
        {
            this.patchService = patchService;
            this.gardenService = gardenService;
        }

        // GET: Patches
        public async Task<IActionResult> Index()
        {
            List<Patch> patches = await patchService.FindAll();
            return View(patches);
        }

        // GET: Patches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patch returnedPatch = await patchService.FindById((int)id);

           if (returnedPatch == null)
            {
                return NotFound();
            }

            return View(returnedPatch);
        }

        // GET: Patches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Crop,GardenId")] Patch patch)
        {
            if (ModelState.IsValid)
            {
                Patch returnedPatch = await patchService.AddPatch(patch);
                return RedirectToAction(nameof(Index));
            }
            return View(patch);
        }

        // GET: Patches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Patch returnedPatch = await patchService.FindById((int)id);
            if (returnedPatch == null)
            {
                return NotFound();
            }
            return View(returnedPatch);
        }

        // POST: Patches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Crop,GardenId")] Patch patch)
        {
            if (id != patch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Patch returnedPatch = await patchService.EditPatch(patch);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatchExists(patch.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GardenId"] = new SelectList(gardenService.FindById "Id", patch.Id);
                //gardenService.FindAll, "Id", "Id", patch.GardenId);
            return View(patch);
        }

        // GET: Patches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patch patch = await patchService.FindById((int) id);
 
            if (patch == null)
            {
                return NotFound();
            }

            return View(patch);
        }

        // POST: Patches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await patchService.DeletePatch(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PatchExists(int id)
        {
           return patchService.FindById(id) != null;
        }
    }
}
