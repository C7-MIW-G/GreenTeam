using GreenTeam.Data;
using GreenTeam.Implementations;
using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GreenTeam.Services
{
    public class GardenService : IGardenService
    {
        private ApplicationDbContext context;
        private readonly IUserService userService;

        public GardenService(ApplicationDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;

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
                .Include(garden => garden.Patches)
                .Include(au => au.GardenUsers)
                .ThenInclude(th => th.User);
            
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

        public async Task<GardenVM> GetVMById(int id)
        {
            Garden garden = await FindById(id);
            Mapper mapper = new Mapper();
            GardenVM gardenVM = mapper.ToVM(garden);

            return gardenVM;
        }

        public async Task<GardenOverviewVM> GetOverviewVM(int id, string userId)
        {
            GardenVM gardenVM = await GetVMById(id);
          
            PatchService patchService = new PatchService(context); //Move to UserService
            bool isGardenManager = await userService.IsManager(userId, gardenVM.Id);

            GardenOverviewVM gardenOverviewVM = new GardenOverviewVM()
            {
                GardenVM = gardenVM,
                IsGardenManager = isGardenManager
            };

            return gardenOverviewVM;
        }
    }
}

