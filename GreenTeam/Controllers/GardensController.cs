#nullable disable
using GreenTeam.Implementations;
using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenTeam.Controllers
{
    public class GardensController : Controller
    {

        private readonly IGardenService gardenService;
        private readonly IUserService userService;
        private readonly ImageConverter imageConverter;
        private readonly IImageService imageService;
        private Mapper mapper;

        public GardensController(IGardenService gardenService,
            IUserService userService, ImageConverter imageConverter, IImageService imageService, Mapper mapper)
        {
            this.gardenService = gardenService;
            this.userService = userService;
            this.imageConverter = imageConverter;
            this.imageService = imageService;
            this.mapper = mapper;
        }

        // GET: Gardens
        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<GardenVM> gardenVMs = await gardenService.GetGardensByCurrentUser();
            return View(gardenVMs);
        }

        // GET: Gardens/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            string userId = userService.GetCurrentUserId();

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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location")] Garden garden, IFormFile files)
        {
            if (ModelState.IsValid)
            {
                if (files != null && files.Length > 0)
                {
                    Image image = imageConverter.CreateImage(files);
                    
                    int imageId = await imageService.AddImage(image);

                    garden.ImageId = imageId;
                }

                await gardenService.AddGarden(garden);

                string userId = userService.GetCurrentUserId();
                await userService.AssignManager(userId, garden.Id);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Gardens/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GardenVM gardenVM = await gardenService.GetVMById((int)id);
            if (gardenVM == null)
            {
                return NotFound();
            }
            return View(gardenVM);
        }

        // POST: Gardens/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location")] Garden garden, IFormFile files)
        {
            if (id != garden.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (files != null && files.Length > 0)
                {
                    Image image = imageConverter.CreateImage(files);

                    int imageId = await imageService.EditImage(image);
                    garden.ImageId = image.Id;
                }
               
                try
                {
                    await gardenService.EditGarden(garden);
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
            GardenVM gardenVM = await gardenService.GetVMById(id);
            return View(gardenVM);
        }

        // GET: Gardens/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GardenVM gardenVM = await gardenService.GetVMById((int)id);

            if (gardenVM == null)
            {
                return NotFound();
            }

            return View(gardenVM);
        }

        // POST: Gardens/Delete/5
        [Authorize]
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
