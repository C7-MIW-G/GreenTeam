using GreenTeam.Data;
using GreenTeam.Implementations;
using GreenTeam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<AppUser> StoreFullName(AppUser user, string name)
        {
            user.FullName = name;

            context.Users.Attach(user);
            context.Entry(user).Property(x => x.FullName).IsModified = true;
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<string> GetFullName(AppUser user)
        {
            var query = context.Users
                .Where(u => u.UserName == user.UserName);

            AppUser returnedUser = await query.FirstOrDefaultAsync();

            return returnedUser.FullName;
        }

        public async Task<bool> IsManager(string userId, int gardenId) //Move to UserService
        {
            var query = context.GardenUser
                .Where(gu => gu.UserId == userId && gu.GardenId == gardenId);

            GardenUser gardenUser = await query.FirstOrDefaultAsync();

            if (gardenUser != null)
            {
                return gardenUser.IsGardenManager;
            }
            return false;
        }
    }    
}
