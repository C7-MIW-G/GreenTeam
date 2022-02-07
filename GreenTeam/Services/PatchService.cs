using GreenTeam.Models;
using GreenTeam.Data;
using Microsoft.EntityFrameworkCore;

namespace GreenTeam.Services
{
    public class PatchService : IPatchService
    {
        public ApplicationDbContext context;
    
        public PatchService(ApplicationDbContext context)
        {
            this.context = context;
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
            Patch patch = await context.Patch.FindAsync(id);
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
    }
}
