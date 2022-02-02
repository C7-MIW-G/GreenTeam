using GreenTeam.Data;
using GreenTeam.Models;
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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Garden garden = await context.Garden.FindAsync(id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.
            return garden;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Garden> AddGarden(Garden garden)
        {
            context.Add(garden);
            await context.SaveChangesAsync();
            return garden;
        }
    }
}

