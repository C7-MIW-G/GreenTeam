using GreenTeam.Data;
using GreenTeam.Implementations;
using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GreenTeam.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly Mapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(ApplicationDbContext context, Mapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return userId;
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

        public async Task<GardenUser> AssignManager(string userId, int gardenId)
        {
            GardenUser gardenUser = new GardenUser()
            {
                GardenId = gardenId,
                UserId = userId,
                IsGardenManager = true
            };
            context.GardenUser.Add(gardenUser);

            await context.SaveChangesAsync();

            return gardenUser;
        }

        /// <summary>
        /// Checks if the given userID belongs to a user that manages the given garden
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gardenId"></param>
        /// <returns>true if the given user(id) is a manager of the garden </returns>
        public async Task<bool> IsManager(string userId, int gardenId)
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
        /// <summary>
        /// Checks if currently logged in user is manager of the given gardenId
        /// </summary>
        /// <param name="gardenId"></param>
        /// <returns>true if the currently logged-in user is a manager of the garden</returns>
        public async Task<bool> IsManager(int gardenId)
        {
            string userId = GetCurrentUserId();
            bool isManager = await IsManager(userId, gardenId);

            return isManager;
        }

        public async Task<bool> IsAuthorized(int gardenId)
        {
            string userId = GetCurrentUserId();

            var query = context.GardenUser
                .Where(gu => gu.UserId == userId && gu.GardenId == gardenId);
            
            GardenUser gardenUser = await query.FirstOrDefaultAsync();

            if (gardenUser == null)
            {
                return false;
            }
            return true;
        }

        public async Task<AppUserVM> GetAppUserVMByEmail(string email)
        {
            AppUserVM foundUser = null;

            var query = context.Users
                .Where(u => u.Email == email);

            AppUser user = await query.FirstOrDefaultAsync();

            if (user != null)
            {
                foundUser = mapper.ToVM(user);

            }
            return foundUser;
        }

        public async Task AssignMemberToGarden(AppUserVM user, int gardenId)
        {
            string userId = await GetUserIdByEmail(user.UserEmail); //wat geeft ie terug


            // throw new KeyNotFoundException("not found");
            GardenUser gardenUser = new GardenUser()
            {
                UserId = userId,
                GardenId = gardenId,
                IsGardenManager = false
            };

            context.GardenUser.Add(gardenUser);
            await context.SaveChangesAsync();
        }

        public async Task<string> GetUserIdByEmail(string email)
        {
            var query = context.AppUser.
                Where(x => x.Email == email);

            AppUser appUser = await query.FirstOrDefaultAsync();
            string userId = appUser.Id;

            return userId;
        }
    }
}
