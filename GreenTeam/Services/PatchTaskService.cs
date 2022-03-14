using GreenTeam.Data;
using GreenTeam.Implementations;
using GreenTeam.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenTeam.Services
{
    public class PatchTaskService : IPatchTaskService
    {
        public ApplicationDbContext context;

        public PatchTaskService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<PatchTask> AddPatchTask(PatchTask patchTask)
        {
            context.Add(patchTask);
            await context.SaveChangesAsync();
            return patchTask;
        }

        public async Task<List<PatchTask>> FindByPatchId(int Id)
        {
            List<PatchTask> allPatchTasks = await context.PatchTask.ToListAsync();
            List<PatchTask> patchTasks = new List<PatchTask>();
            foreach (var patchTask in allPatchTasks)
            {
                if (patchTask.PatchId == Id)
                {
                    patchTasks.Add(patchTask);
                }
            }
            return patchTasks;
        }

        public async Task<PatchTask> FindById(int id)
        {
            PatchTask patchTask = await context.PatchTask.FindAsync(id);
            return patchTask;
        }

        public async Task<PatchTask> EditPatchTask(PatchTask patchTask)
        {
            context.Update(patchTask);
            await context.SaveChangesAsync();
            return patchTask;
        }

        public async Task<PatchTask> DeletePatchTask(int id)
        {
            PatchTask patchTask = await FindById(id);
            context.Remove(patchTask);
            await context.SaveChangesAsync();
            return patchTask;
        }

        public async Task<PatchTask> CompletePatchTask(int id)
        {
            PatchTask patchTask = await FindById(id);
            patchTask.IsCompleted = true;
            context.Update(patchTask);
            await context.SaveChangesAsync();
            return patchTask;
        }

        public async Task<PatchTask> SoftDeletePatchTask(int id)
        {
            PatchTask patchTask = await FindById(id);
            patchTask.IsDeleted = true;
            context.Update(patchTask);
            await context.SaveChangesAsync();
            return patchTask;
        }
    }
}
