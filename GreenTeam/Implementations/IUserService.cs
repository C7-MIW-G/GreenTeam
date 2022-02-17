using GreenTeam.Models;

namespace GreenTeam.Implementations
{
    public interface IUserService
    {
        Task<List<GardenUser>> FindByGardenId(int id);
    }
}
