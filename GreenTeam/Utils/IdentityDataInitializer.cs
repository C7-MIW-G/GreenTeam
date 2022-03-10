using GreenTeam.Models;
using Microsoft.AspNetCore.Identity;

namespace GreenTeam.Utils
{
    public class IdentityDataInitializer
    {
        public void SeedData(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager )
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);  
        }

        public void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }     

        public async void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@greenteam.com").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "admin@greenteam.com";
                user.Email = "admin@greenteam.com";
                user.FullName = "Administrator";                                                                                              

                IdentityResult result = userManager.CreateAsync(user, "Test123!").Result;

                if (result.Succeeded)
                {
                   await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }
    }
}
