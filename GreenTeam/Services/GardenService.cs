using GreenTeam.Data;
using GreenTeam.Implementations;
using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using GreenTeam.Utils;

namespace GreenTeam.Services
{
    public class GardenService : IGardenService
    {
        private readonly ApplicationDbContext context;
        private readonly Mapper mapper;
        private readonly IUserService userService;

        public GardenService(ApplicationDbContext context, IUserService userService, Mapper mapper)
        {
            this.context = context;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<List<Garden>> FindAll()
        {
            List<Garden> gardens = await context.Garden.ToListAsync();
         
            return gardens;
        }

        public async Task<List<GardenVM>> GetGardensByCurrentUser()
        {
            List<GardenVM> gardenVms = new();

            string userId = userService.GetCurrentUserId();

            var query = context.GardenUser
                .Where(x => x.UserId == userId)
                .Include(y => y.Garden);

            List<GardenUser> gardenUsers = await query.ToListAsync();

            foreach (GardenUser gardenUser in gardenUsers)
            {
                GardenVM gardenVM = mapper.ToVM(gardenUser.Garden);
                gardenVms.Add(gardenVM);
            }

            return gardenVms;
        }

        public async Task<List<GardenVM>> GetAllGardenVMs()
        {
            List<Garden> gardens = await FindAll();
            List<GardenVM> gardenVMs = new List<GardenVM>();
            
            foreach(Garden garden in gardens)
            {
                gardenVMs.Add(mapper.ToVM(garden));                
            }
            
            return gardenVMs;
        }

        public async Task<Garden> FindById(int id)
        {
            var query = context.Garden
                .Where(garden => garden.Id == id)
                .Include(garden => garden.Patches)
                .Include(au => au.GardenUsers)
                .ThenInclude(th => th.User)
                .Include(gi => gi.Image);

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
            GardenVM gardenVM = mapper.ToVM(garden);

            return gardenVM;
        }

        public async Task<GardenDetailsVM> GetOverviewVM(int id, string userId)
        {
            GardenVM gardenVM = await GetVMById(id);
          
            bool isGardenManager = await userService.IsManager(userId, gardenVM.Id);

            GardenDetailsVM gardenOverviewVM = new GardenDetailsVM()
            {
                GardenVM = gardenVM,
                IsGardenManager = isGardenManager
            };

            return gardenOverviewVM;
        }
    }
}

