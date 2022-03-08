using GreenTeam.Models;
using GreenTeam.Services;
using GreenTeam.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenTeamUnitTests
{

    [TestClass]
    public class GardenMapperTest
    {

        private Garden CreateFakeGarden()
        {

            /* Create a Patch and add a list of PatchTasks*/
            PatchTask patchTask = new PatchTask() { Id = 1, TaskDescription = "taskDescription", TaskName = "taskName" };
            List<PatchTask> patchTasks = new List<PatchTask>();
            patchTasks.Add(patchTask);

            Patch patch = new Patch()
            {
                Id = 1,
                GardenId = 1,
                Crop = "testCrop",
                PatchName = "testPatchName",

            };
            patchTask.PatchId = patch.Id;
            patch.PatchTasks = patchTasks;

            /* Create a list of Patches*/
            ICollection<Patch> patchList = new List<Patch>();
            patchList.Add(patch);

            /* Create a List of GardenUsers*/
            AppUser appUser = new AppUser()
            {
                FullName = "testFullName"
            };

            GardenUser gardenUser = new GardenUser()
            {
                UserId = "testUserId",
                User = appUser,
                IsGardenManager = true
            };

            ICollection<GardenUser> gardenUsers = new List<GardenUser>();
            gardenUsers.Add(gardenUser);

            /* Create a GardenImage*/
            GardenImage image = new GardenImage()
            {
                Id = 1,
                Name = "gardenImageName",
                FileType = ".jpg",
                CreatedOn = DateTime.Now
            };

            byte[] imageByteArray = { 1, 2, 3, 4, 5, 6, 7 };
            image.Content = imageByteArray;


            /* Create a Garden */
            Garden garden = new Garden()
            {
                Id = 1,
                Name = "gardenTest",
                Location = "locationTest",
                Patches = patchList,
                GardenUsers = gardenUsers,
                GardenImageId = image.Id
            };

            gardenUser.Garden = garden;
            gardenUser.GardenId = garden.Id;
            patch.GardenId = garden.Id;

            return garden;
        }

        [TestMethod]
        public void GardenVMContainsIdProperty()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Garden garden = CreateFakeGarden();

            // Act
            GardenVM gardenVM = mapper.ToVM(garden);

            // Assert
            Assert.AreEqual(gardenVM.Id, garden.Id, "Garden id's are expected to be equal");
        }

        [TestMethod]
        public void GardenVMContainsName()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Garden garden = CreateFakeGarden();

            // Act
            GardenVM gardenVM = mapper.ToVM(garden);

            // Assert
            Assert.AreEqual(gardenVM.Name, garden.Name, "Garden names are expected to be equal");
        }

        [TestMethod]
        public void GardenVMContainsLocation()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Garden garden = CreateFakeGarden();

            // Act
            GardenVM gardenVM = mapper.ToVM(garden);

            // Assert
            Assert.AreEqual(gardenVM.Location, garden.Location, "Garden locations are expected to be equal");
        }

        [TestMethod]
        public void GardenVMContainsImageGardenId()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Garden garden = CreateFakeGarden();

            // Act
            GardenVM gardenVM = mapper.ToVM(garden);

            // Assert
            Assert.AreEqual(gardenVM.GardenImageId, garden.GardenImageId, "Garden Image Id's are expected to be equal");
        }

        /* Check if loop for adding Patches to PatchList works*/
        [TestMethod]
        public void GardenVMContainsPatchListWithPatches()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Garden garden = CreateFakeGarden();
            List<Patch> patchList = garden.Patches.ToList();

            // Act
            GardenVM gardenVM = mapper.ToVM(garden);
           
            // Assert
            Assert.AreEqual(gardenVM.Patches[0].PatchName, patchList[0].PatchName, "Patchname expected to be equal ");
            Assert.AreEqual(gardenVM.Patches[0].Id, patchList[0].Id, "PatchId expected to be equal");
        }
        
        /* Check if loop for adding GardenUsers to GardenUserList works*/
        [TestMethod]
        public void GardenVMContainsUserlsListWithGardenUsers()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Garden garden = CreateFakeGarden();
            List<GardenUser> gardenUserList = garden.GardenUsers.ToList();

            // Act
            GardenVM gardenVM = mapper.ToVM(garden);

            // Assert
            Assert.AreEqual(gardenVM.Users[0].UserEmail, gardenUserList[0].User.Email, "E-mail addresses are expected to be equal ");
        }
    }
}
