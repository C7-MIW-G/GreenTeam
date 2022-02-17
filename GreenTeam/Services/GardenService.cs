using GreenTeam.Data;
using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GreenTeam.Services
{
    public class GardenService : IGardenService
    {
        private ApplicationDbContext context;

        public GardenService(ApplicationDbContext context)
        {
            this.context = context;

        }

        public async Task<List<Garden>> FindAll()
        {
            List<Garden> gardens = await context.Garden.ToListAsync();
            return gardens;
        }

        public async Task<Garden> FindById(int id)
        {
            var query = context.Garden
                .Where(garden => garden.Id == id)
                .Include(garden => garden.Patches);         


            Garden garden = await query.FirstOrDefaultAsync();

            return garden;
        }

        public async Task<Garden> AddGarden(Garden garden)
        {
            context.Add(garden);
            await context.SaveChangesAsync();
            return garden;
        }

        public async Task<Garden> EditGarden(Garden garden)
        {
            context.Update(garden);
            await context.SaveChangesAsync();
            return garden;
        }

        public async Task<Garden> DeleteGarden(int id)
        {

            Garden garden = await FindById(id);
            context.Garden.Remove(garden);
            await context.SaveChangesAsync();

            return garden;

        }
    }
}

