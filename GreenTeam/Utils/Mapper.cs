using GreenTeam.Models;
using GreenTeam.ViewModels;

namespace GreenTeam.Utils
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

            if (gardenModel.GardenUsers != null)
            {
                List<GardenUser> gardenUsers = gardenModel.GardenUsers.ToList();

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
                Users = appUserVMs,
                GardenImageId = gardenModel.GardenImageId,
                GardenImage = gardenModel.GardenImage,
            };

            return vm;
        }

        public PatchVM ToVM(Patch patchModel)
        {
            List<PatchTaskVM> patchTaskVMs = new List<PatchTaskVM>();

            if (patchModel.PatchTasks != null)
            {
                foreach (PatchTask patchTask in patchModel.PatchTasks)
                {
                    patchTaskVMs.Add(ToVM(patchTask));
                }
            }

            PatchVM vm = new PatchVM()
            {
                Id = patchModel.Id,
                PatchName = patchModel.PatchName,
                Crop = patchModel.Crop,
                PatchTasks = patchTaskVMs,
                GardenId = patchModel.GardenId
            };


            return vm;
        }

        public AppUserVM ToVM(AppUser appUser)
        {
            if (appUser == null)
            {
                return new AppUserVM();
            }

            AppUserVM vm = new AppUserVM()
            {
                UserEmail = appUser.Email,
                UserName = appUser.FullName,
            };

            return vm;
        }

        public PatchTaskVM ToVM(PatchTask patchTaskModel)
        {
            PatchTaskVM vm = new PatchTaskVM()
            {
                Id = patchTaskModel.Id,
                PatchId = patchTaskModel.PatchId,
                TaskName = patchTaskModel.TaskName,
                TaskDescription = patchTaskModel.TaskDescription
            };

            return vm;
        }
    }
}