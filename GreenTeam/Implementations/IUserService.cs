using GreenTeam.Models;
using Microsoft.AspNetCore.Identity;

namespace GreenTeam.Implementations
{
    public interface IUserService
    {
        Task<List<GardenUser>> FindByGardenId(int id);
        void StoreFullName(AppUser user, string name);
        Task<string> GetFullName(AppUser user);
    }            
}
