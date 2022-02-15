using GreenTeam.Data;
using GreenTeam.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenTeam.Services
{
    public class UserService : IUserService
    {
        public ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<GardenUser>> FindByGardenId(int id)
        {
            List<GardenUser> allGardenUsers = await context.GardenUser.ToListAsync();
            List<GardenUser> memberList = new List<GardenUser>();
            foreach (var gardenUser in allGardenUsers)
            {
                if (gardenUser.GardenId == id)
                {
                    memberList.Add(gardenUser);
                }
            }
            return memberList;
        }
    }

    
}
