using GreenTeam.Models;

namespace GreenTeam.Services
{
    public interface IUserService
    {
        Task<List<GardenUser>> FindByGardenId(int id);
    }
}
