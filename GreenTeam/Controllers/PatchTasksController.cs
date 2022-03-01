using GreenTeam.Implementations;
using GreenTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GreenTeam.Controllers
{
    public class PatchTasksController : Controller
    {
        private readonly IPatchTaskService patchTaskService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatchTasksController(IPatchTaskService PatchTaskService, IHttpContextAccessor httpContextAccessor)
        {
            this.patchTaskService = PatchTaskService;
            this._httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get: PatchTasks/Create
        public IActionResult Create(int PatchId)
        {
            return View();
        }

        //POST: PatchTasks/Create/[patchid]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Patch, PatchId, TaskName, TaskDescription")]PatchTask patchTask)
        {
            if (ModelState.IsValid)
            {
                PatchTask returnedPatchTask = await patchTaskService.AddPatchTask(patchTask);
                return RedirectToAction(nameof(Index));
            }
            return View(patchTask);
        }

        //GET: PatchTasks/Edit/6
        public async Task<IActionResult> Edit(int id)
        {
            PatchTask returnedPatchTask = await patchTaskService.FindById(id);
            return View(returnedPatchTask);

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
                PatchTask returnedPatchTask = await patchTaskService.EditPatchTask(patchTask);

                return RedirectToAction("Details", "PatchTasks", new { id = patchTask.Id });
            }
            return View(patchTask);
        }

        //Get: PatchTasks/Delete/6
        public async Task<IActionResult> Delete(int id)
        {
            PatchTask patchTask = await patchTaskService.FindById(id);

            if (patchTask == null)
            {
                return NotFound();
            }
            return View(patchTask);
        }

        //POST: PatchTasks/Delete/6
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PatchTask patchTaskToDelete = await patchTaskService.DeletePatchTask(id);
            return RedirectToAction("Details", "PatchTasks", new { id = patchTaskToDelete.Id });
        }
    }
}

