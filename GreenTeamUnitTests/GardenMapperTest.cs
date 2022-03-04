using GreenTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeamUnitTests
{
    
    
    internal class GardenMapperTest
    {

        public Garden FakeGarden()
        {
            Garden garden = new Garden()
            {
                Id = 1,
                Name = "gardenTest",
                Location = "locationTest",
                GardenUsers = new List<GardenUser>(),
                GardenImageId = 1
            };

            Patch patch = new Patch()
            {
                Id = 1,
                GardenId = 1,
                Crop = "testCrop",
                PatchName = "testPatchName",
            };

            GardenUser user = new GardenUser() { UserId = "mockUserId", User = null, IsGardenManager = false, GardenId = 1, Garden = garden };

            PatchTask patchTask = new PatchTask() { Id = 1, PatchId = 1, TaskDescription = "taskDescription", TaskName = "taskName" };
            List<PatchTask> patchTasks = new List<PatchTask>();
            patchTasks.Add(patchTask);
            patch.PatchTasks = patchTasks;

            List<Patch> patchList = new List<Patch>();
            patchList.Add(patch);
            garden.Patches = patchList;

            List<GardenUser> gardenUserList = new List<GardenUser>();
            gardenUserList.Add(user);
            garden.GardenUsers = gardenUserList;

            return garden;
        }
    }
}
