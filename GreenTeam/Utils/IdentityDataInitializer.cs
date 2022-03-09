using Microsoft.AspNetCore.Identity;

namespace GreenTeam.Utils
{
    public class IdentityDataInitializer
    {
        public void SeedData(RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
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
    }
}
