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
using GreenTeam.ViewModels;
using GreenTeam.Services;

namespace GreenTeam.Controllers
{
    public class GardensController : Controller
    {
                                                                
        private readonly IGardenService gardenService;
        private readonly IPatchService patchService;

        public GardensController(IGardenService gardenService, IPatchService patchService)
        {
            this.gardenService = gardenService;
            this.patchService = patchService;
        }

        // GET: Gardens
        public async Task<IActionResult> Index()
        {
            List<Garden> gardens = await gardenService.FindAll();
            return View(gardens);
        }

        // GET: Gardens/Details/5
        public async Task<IActionResult> Details(int id)
        {

            Garden returnedGarden = await gardenService.FindById(id);
            List<Patch> patchList = await patchService.FindByGardenId(id);

            GardenView gardenView = Mapper.createGardenView(returnedGarden, patchList);

           if (gardenView == null)
            {
                return NotFound();
            }

            return View(gardenView);
        }

        // GET: Gardens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gardens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location")] Garden garden)
        {
            if (ModelState.IsValid)
            {
                Garden returnedGarden = await gardenService.AddGarden(garden);
                return RedirectToAction(nameof(Index));
            }
            return View(garden);
        }

        // GET: Gardens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Garden returnedGarden = await gardenService.FindById((int)id);
            if (returnedGarden == null)
            {
                return NotFound();
            }
            return View(returnedGarden);
        }

        // POST: Gardens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location")] Garden garden)
        {
            if (id != garden.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Garden returnedGarden = await gardenService.EditGarden(garden);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GardenExists(garden.Id))
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
            return View(garden);
        }

        // GET: Gardens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Garden garden = await gardenService.FindById((int) id);
 
            if (garden == null)
            {
                return NotFound();
            }

            return View(garden);
        }

        // POST: Gardens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await gardenService.DeleteGarden(id);
            return RedirectToAction(nameof(Index));
        }

        private bool GardenExists(int id)
        {
           return gardenService.FindById(id) != null;
        }
    }
}
