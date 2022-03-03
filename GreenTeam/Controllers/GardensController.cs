#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using GreenTeam.Implementations;
using System.Security.Claims;
using System;
using System.IO;
using GreenTeam.Data;

namespace GreenTeam.Controllers
{
    public class GardensController : Controller
    {

        private readonly IGardenService gardenService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserService userService;
        private readonly ApplicationDbContext context;
        
        public GardensController(IGardenService gardenService, IHttpContextAccessor httpContextAccessor, IUserService userService, ApplicationDbContext context)
        {
            this.gardenService = gardenService;
            this.httpContextAccessor = httpContextAccessor;
            this.userService = userService;
            this.context = context;
        }

        // GET: Gardens
        public async Task<IActionResult> Index()
        {
            List<GardenVM> gardenVMs = await gardenService.GetAllGardenVMs();
            return View(gardenVMs);
        }

        // GET: Gardens/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            GardenVM gardenView = await gardenService.GetVMById(id);
            string userId = "";

            userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            GardenDetailsVM gardenOverviewVM = await gardenService.GetOverviewVM(id, userId);

            if (gardenOverviewVM == null)
            {
                return NotFound();
            }

            return View(gardenOverviewVM);
        }

        // GET: Gardens/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gardens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location")] Garden garden, IFormFile files)
        {
            if (ModelState.IsValid)
            {
                Garden returnedGarden = await gardenService.AddGarden(garden);
               
                string userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                await userService.AssignManager(userId, garden.Id);

                if (files != null)
                {
                    if (files.Length > 0)
                    {
                        var fileName = Path.GetFileName(files.FileName);

                        var fileExtension = Path.GetExtension(fileName);

                        var newFileName = string.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var objFiles = new GardenImage()
                        {
                            Id = 0,
                            Name = newFileName,
                            FileType = fileExtension,
                            CreatedOn = DateTime.Now
                        };

                        using (var target = new MemoryStream())
                        {
                            files.CopyTo(target);
                            objFiles.Content = target.ToArray();
                        }

                        context.GardenImage.Add(objFiles);
                        context.SaveChanges();
                    }
                }

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

            Garden garden = await gardenService.FindById((int)id);

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
