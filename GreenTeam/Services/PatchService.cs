using GreenTeam.Models;
using GreenTeam.Data;
using Microsoft.EntityFrameworkCore;
using GreenTeam.Implementations;
using GreenTeam.ViewModels;
using GreenTeam.Utils;

namespace GreenTeam.Services
{
    public class PatchService : IPatchService
    {
        readonly ApplicationDbContext context;
        private Mapper mapper;

        public PatchService(ApplicationDbContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Patch> AddPatch(Patch patch)
        {
            context.Add(patch);
            await context.SaveChangesAsync();

            return patch;
        }

        public async Task<List<Patch>> FindByGardenId(int Id)
        {
            List<Patch> allPatches = await context.Patch.ToListAsync();
            List<Patch> patches = new List<Patch>();
            foreach (var patch in allPatches)
            {
                if (patch.GardenId == Id)
                {
                    patches.Add(patch);
                }
            }
            return patches;
        }

        public async Task<Patch> FindById(int id)
        {
            var query = context.Patch
                .Where(a => a.Id == id)
                .Include(b => b.PatchTasks);

            Patch patch = await query.FirstOrDefaultAsync();

            return patch;
        }

        public async Task<Patch> EditPatch(Patch patch)
        {
            context.Update(patch);
            await context.SaveChangesAsync();

            return patch;
        }

        public async Task<Patch> DeletePatch(int id)
        {
            Patch patch = await FindById(id);
            context.Remove(patch);
            await context.SaveChangesAsync();

            return patch;
        }

        public async Task<PatchVM> GetVMById(int id)
        {
            Patch patch = await FindById(id);
            PatchVM patchVM = mapper.ToVM(patch);

            return patchVM;
        }

        public async Task<PatchVM> GetDetailsVM(int id)
        {
            PatchVM patchVM = await GetVMById(id);

            return patchVM;
        }

        public async Task<List<PatchVM>> GetAllPatchVMs()
        {
            List<Patch> patches = await context.Patch.ToListAsync();
            List<PatchVM> patchVMs = new List<PatchVM>();

            foreach (Patch patch in patches)
            {
                patchVMs.Add(mapper.ToVM(patch));
            }

            return patchVMs;
        }

        public async Task<int> GetGardenIdByPatchId(int patchId)
        {
            var query = context.Patch
                .Where(a => a.Id == patchId);

            Patch patch = await query.FirstOrDefaultAsync();

            if (patch == null)
            {
                return 0;
            }
            int gardenId = patch.GardenId;

            return gardenId;
        }
    }
}
