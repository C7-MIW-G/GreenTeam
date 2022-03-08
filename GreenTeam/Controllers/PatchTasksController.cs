using GreenTeam.Implementations;
using GreenTeam.Models;
using GreenTeam.Services;
using GreenTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GreenTeam.Controllers
{
    public class PatchTasksController : Controller
    {
        private readonly IPatchTaskService patchTaskService;
        private readonly Mapper mapper;


        public PatchTasksController(IPatchTaskService PatchTaskService, Mapper mapper)
        {
            this.patchTaskService = PatchTaskService;
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
        public async Task<IActionResult> Create([Bind("Id, Patch, PatchId, TaskName, TaskDescription")]PatchTask patchTask)
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

        //POST: PatchTasks/Delete/6
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PatchTask patchTaskToDelete = await patchTaskService.DeletePatchTask(id);
            return RedirectToAction("Details", "Patches", new { id = patchTaskToDelete.PatchId });
        }
    }
}

