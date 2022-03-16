using GreenTeam.Models;
using GreenTeam.ViewModels;

namespace GreenTeam.Implementations
{
    public interface IUserService
    {
        string GetCurrentUserId();
        Task<List<GardenUser>> FindByGardenId(int id);
        Task<AppUser> StoreFullName(AppUser user, string name);
        Task<string> GetFullName(AppUser user);
        Task<GardenUser> AssignManager(string userId, int gardenId);
        Task<bool> IsManager(int gardenId);
        Task<bool> IsManager(string userId, int gardenId);
        Task<bool> IsAuthorizedToAccessGarden(int gardenId);
        Task<AppUserVM> GetAppUserVMByEmail(string email);
        Task AssignMemberToGarden(AppUserVM user, int gardenId);
        Task<string> GetUserIdByEmail(string email);
        Task RemoveMemberFromGarden(string userEmail, int gardenId);
    }
}
