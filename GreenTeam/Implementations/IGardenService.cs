using GreenTeam.Models;
using GreenTeam.ViewModels;

namespace GreenTeam.Implementations
{
    public interface IGardenService
    {
        Task<Garden> FindById(int Id);
        Task<List<Garden>> FindAll();
        Task<Garden> AddGarden(Garden garden);
        Task<Garden> EditGarden(Garden garden);
        Task<Garden> DeleteGarden(int id);

        Task<GardenVM> GetVMById(int id);
        Task<GardenOverviewVM> GetOverviewVM(int id, string userId);
    }
}
