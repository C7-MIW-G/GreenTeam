using GreenTeam.ViewModels;
using GreenTeam.Models;

namespace GreenTeam.Services
{
    public class Mapper
    {

        public GardenVM ToVM(Garden gardenModel)
        {
            List<PatchVM> patchVMs = new List<PatchVM>();                     
            List<AppUserVM> appUserVMs = new List<AppUserVM>();

            if (gardenModel.Patches != null)
            {
                foreach (Patch patch in gardenModel.Patches)
                {
                    patchVMs.Add(ToVM(patch));
                }
            }

            List<GardenUser> gardenUsers = gardenModel.GardenUsers.ToList();

            if (gardenUsers != null)
            {
                for (int userIndex = 0; userIndex < gardenUsers.Count; userIndex++)
                {
                    appUserVMs.Add(ToVM(gardenUsers[userIndex].User));
                    appUserVMs[userIndex].IsGardenManager = gardenUsers[userIndex].IsGardenManager;

                }                
            }
                       
            GardenVM vm = new GardenVM()
            {
                Id = gardenModel.Id,
                Name = gardenModel.Name,
                Location = gardenModel.Location,
                Patches = patchVMs,
                Users = appUserVMs
            };

            return vm;
        }

        public PatchVM ToVM(Patch patchModel)
        {

            PatchVM vm = new PatchVM()
            {
                Id = patchModel.Id,
                PatchName = patchModel.PatchName,
                Crop = patchModel.Crop
            };

            return vm;
        }

        public AppUserVM ToVM(AppUser appUser)
        {

            AppUserVM vm = new AppUserVM()
            {
                UserEmail = appUser.Email,
                UserName = appUser.FullName,
               
        
            };

            return vm;
        }
    }
}