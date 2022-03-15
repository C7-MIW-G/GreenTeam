using GreenTeam.Models;
using Microsoft.AspNetCore.Identity;

namespace GreenTeam.Utils
{
    public class IdentityDataInitializer
    {
        public async Task SeedData(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            SeedRoles(roleManager);
            await SeedUsers(userManager);
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

        public async Task SeedUsers(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                if (userManager.FindByNameAsync("admin@greenteam.com").Result == null)
                {
                    AppUser adminUser = new AppUser();
                    adminUser.Id = "8ebcaf9d-6a6a-438d-8991-018efadd2127";
                    adminUser.UserName = "admin@greenteam.com";
                    adminUser.Email = "admin@greenteam.com";
                    adminUser.FullName = "Administrator";

                    IdentityResult result = userManager.CreateAsync(adminUser, "Test123!").Result;

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Administrator");
                    }
                }

                // Migrate to File
                string[] idArray =
                {
                    "87c8a42e-d229-4b71-8015-42333bb53ee7",
                    "91f6f1a2-9a0c-469d-aabc-67ed46d7dab6",
                    "375632ae-cdfc-4d4e-9531-59b26f7cf781",
                    "70bd5baf-67b9-48af-9381-cd9bf7a3c8eb",
                    "9fa5d40b-d92b-49be-a314-9b7e035f995c",
                    "4b6d6804-0ef2-4a4a-834b-eb5df7b964b6",
                    "1d78d3ed-7cfa-44c2-a43e-0c32905ccd3b",
                    "f29d1f87-0dcd-4a62-a059-6bca9a44c96c",
                    "d063274d-acf9-4af4-ab55-3ee37b5fe72b",
                    "c2f7b956-e333-4795-a677-43299e46474c",
                    "5112fef4-7b6f-448d-b01f-0b7902df99cd",
                    "2d347214-365d-4891-a08e-01fe2722c9e0",
                    "d8f70be9-0c6b-46ca-892e-b89c63ebcac0",
                    "72aec0b0-1c32-43c3-bfd7-34bcbaf22e83",
                    "42f1a3b5-929c-499f-9623-9c04b12d3a63",
                    "381a6729-9e91-41f8-947e-0bbb6bcf3ae0"
                };

                // Migrate to File
                string[] userNameArray =
                {
                    "iris@greenteam.com",
                    "marcel@greenteam.com",
                    "noa@greenteam.com",
                    "sem@greenteam.com",
                    "roy@greenteam.com",
                    "sylvia@greenteam.com", 
                    "arjan@greenteam.com", 
                    "jos@greenteam.com",
                    "maartje@greenteam.com",
                    "mina@greenteam.com",
                    "henk@greenteam.com",
                    "tjerk@greenteam.com",
                    "afke@greenteam.com",
                    "caroline@greenteam.com",
                    "hein@greenteam.com",
                    "amanda@greenteam.com"
                };

                // Migrate to File
                string[] emailArray =
                {
                    "iris@greenteam.com",
                    "marcel@greenteam.com",
                    "noa@greenteam.com",
                    "sem@greenteam.com",
                    "roy@greenteam.com",
                    "sylvia@greenteam.com",
                    "arjan@greenteam.com",
                    "jos@greenteam.com",
                    "maartje@greenteam.com",
                    "mina@greenteam.com",
                    "henk@greenteam.com",
                    "tjerk@greenteam.com",
                    "afke@greenteam.com",
                    "caroline@greenteam.com",
                    "hein@greenteam.com",
                    "amanda@greenteam.com"
                };

                // Migrate to File
                string[] fullNameArray =
                {
                    "Iris Hagen",
                    "Marcel Klerken",
                    "Noa Zeegers",
                    "Sem Peters",
                    "Roy Hermans",
                    "Sylvia Albers",
                    "Arjan Baaiman",
                    "Jos Janssen",
                    "Maartje Heijman",
                    "Mina Rutten",
                    "Henk Alberda",
                    "Tjerk Dijkstra",
                    "Afke Veldstra",
                    "Caroline Ramaker",
                    "Hein Kools",
                    "Amanda Boon"
                };

                List<AppUser> appUserList = new List<AppUser>();
                                
                for (int i = 0; i < 16; i++)
                {
                    AppUser appUser = new AppUser()
                    {
                        Id = idArray[i],
                        UserName = userNameArray[i],
                        Email = emailArray[i],
                        FullName = fullNameArray[i]
                    };

                    appUserList.Add(appUser);

                    IdentityResult result = userManager.CreateAsync(appUser, "Test123!").Result;

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(appUser, "User");
                    }
                }               
            }
        }
    }
}
