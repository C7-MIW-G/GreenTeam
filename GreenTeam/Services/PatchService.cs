using GreenTeam.Models;
using GreenTeam.Data;
using Microsoft.EntityFrameworkCore;

namespace GreenTeam.Services
{
    public class PatchService : IPatchService
    {
        private ApplicationDbContext context;
        
        public PatchService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Patch>> FindByGardenId(int Id)
        {
            List<Patch> allPatches = await context.Patch.ToListAsync();
            List<Patch> patches = allPatches.Where(p => p.GardenId == Id).ToList();

            return patches;
        }

        public async Task<Patch> AddPatch(Patch patch)
        {
            context.Add(patch);
            await context.SaveChangesAsync();
            return patch;
        }
    }
}
