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

            
            GardenVM vm = new GardenVM()
            {
                Id = gardenModel.Id,
                Name = gardenModel.Name,
                Location = gardenModel.Location,
                Patches = patchVMs,
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

        public AppUserVM ToVM(GardenUser gardenUserModel)
        {

            AppUserVM vm = new AppUserVM()
            {
                //UserName = gardenUserModel.FullName,
                //UserEmail = gardenUserModel.Email
            };


            return vm;
        }
    }
}