using GreenTeam.Models;
using Microsoft.AspNetCore.Identity;

namespace GreenTeam.Implementations
{
    public interface IUserService
    {
        Task<List<GardenUser>> FindByGardenId(int id);
        Task<AppUser> StoreFullName(AppUser user, string name);
        Task<string> GetFullName(AppUser user);
        Task<GardenUser> AssignManager(string userId, int gardenId);
        Task<bool> IsManager(string userId, int gardenId);
    }            
}
