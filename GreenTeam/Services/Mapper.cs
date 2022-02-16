using GreenTeam.ViewModels;
using GreenTeam.Models;


namespace GreenTeam.Services
{
    public class Mapper
    {

        public GardenVM ToVM(Garden gardenModel)
        {
            List<PatchVM> patchVMs = new List<PatchVM>();
            if (gardenModel.Patches != null)
            {
                foreach (Patch patch in gardenModel.Patches)
                {
                    patchVMs.Add(ToVM(patch));
                }
            }



            List<AppUserVM> appUserVMs = new List<AppUserVM>();
            /*foreach (GardenUser user in gardenModel.GardenUsers)
            {
                appUserVMs.Add(ToVM(user));
            }*/


            GardenVM vm = new GardenVM()
            {
                Id = gardenModel.Id,
                Name = gardenModel.Name,
                Location = gardenModel.Location,
                Patches = patchVMs,
                //Users = appUserVMs
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