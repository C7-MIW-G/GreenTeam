using GreenTeam.Data;
using GreenTeam.Models;
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

        public async Task<List<Patch>> FindAll()
        {
            //List<Patch> patch = 
            return await context.Patch.ToListAsync(); ;
        }

        public async Task<Patch> FindById(int id)
        {
            Patch garden = await context.Patch.FindAsync(id);
            return garden;
        }

        public async Task<Patch> AddPatch(Patch garden)
        {
            context.Add(garden);
            await context.SaveChangesAsync();
            return garden;
        }

        public async Task<Patch> EditPatch(Patch garden)
        {
            context.Update(garden);
            await context.SaveChangesAsync();
            return garden;
        }

        public async Task<Patch> DeletePatch(int id)
        {

            Patch garden = await FindById(id);
            context.Patch.Remove(garden);
            await context.SaveChangesAsync();

            return garden;

        }
    }
}

