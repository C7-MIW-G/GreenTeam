using GreenTeam.Implementations;
using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GreenTeam.Controllers
{
    public class PatchTasksController : Controller
    {
        private readonly IPatchService patchService;
        private readonly IPatchTaskService patchTaskService;
        private readonly IGardenService gardenService;
        private readonly Mapper mapper; 


        public PatchTasksController(
            IPatchService PatchService,
            IPatchTaskService PatchTaskService,
            IGardenService gardenService,
            Mapper mapper
            )
        {
            this.patchService = PatchService;
            this.patchTaskService = PatchTaskService;
            this.gardenService = gardenService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get: PatchTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: PatchTasks/Create/[patchid]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Patch, PatchId, TaskName, TaskDescription")] PatchTask patchTask)
        {

            if (!ModelState.IsValid)
            {
                await patchTaskService.AddPatchTask(patchTask);
                return RedirectToAction("Details", "Patches", new { id = patchTask.PatchId });
            }
            PatchTaskVM patchTaskVM = mapper.ToVM(patchTask);
            return View(patchTaskVM);
        }
        //GET: PatchTasks/Edit/6
        public async Task<IActionResult> Edit(int id)
        {
            PatchTask returnedPatchTask = await patchTaskService.FindById(id);
            PatchTaskVM patchTaskVM = mapper.ToVM(returnedPatchTask);
            return View(patchTaskVM);

        }

        //POST: PatchTasks/Edit/6
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Patch, PatchId, TaskName, TaskDescription")] PatchTask patchTask)
        {
            if (id != patchTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await patchTaskService.EditPatchTask(patchTask);
                return RedirectToAction("Details", "Patches", new { id = patchTask.PatchId });
            }
            PatchTaskVM patchTaskVM = mapper.ToVM(patchTask);
            return View(patchTaskVM);
        }

        //Get: PatchTasks/Delete/6
        public async Task<IActionResult> Delete(int id)
        {
            PatchTask patchTask = await patchTaskService.FindById(id);
            PatchTaskVM patchTaskVM = mapper.ToVM(patchTask);

            if (patchTask == null)
            {
                return NotFound();
            }
            return View(patchTaskVM);
        }

        //POST: PatchTask/Complete
        //Sets PatchTask boolean IsComplete to True
        [HttpPost, ActionName("Complete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompletePatchTask(int id)
        {
            PatchTask patchTask = await patchTaskService.CompletePatchTask(id);
            Patch patch = await patchService.FindById(patchTask.PatchId);
            Garden garden = await gardenService.FindById(patch.GardenId);
            GardenVM gardenVM = mapper.ToVM(garden);

            return RedirectToAction("Details", "Gardens", new { id = patch.GardenId });
        }

        //POST: PatchTasks/Delete/6
        //Sets PatchTask boolean IsDeleted to True
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PatchTask patchTask = await patchTaskService.SoftDeletePatchTask(id);
            Patch patch = await patchService.FindById(patchTask.PatchId);
            Garden garden = await gardenService.FindById(patch.GardenId);
            GardenVM gardenVM = mapper.ToVM(garden);

            return RedirectToAction("Details", "Gardens", new { id = patch.GardenId });
        }
    }
}

