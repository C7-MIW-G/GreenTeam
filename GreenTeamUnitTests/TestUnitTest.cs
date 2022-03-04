using GreenTeam.Models;
using GreenTeam.Services;
using GreenTeam.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace GreenTeamUnitTests
{
    [TestClass]
    public class TestUnitTest
    {
        [TestMethod]
        public void MainTest()
        {
            // Arrange
            int a = 1;
            int b = 2;

            // Act
            int result = a + b;

            // Assert
            Assert.AreEqual(3, result, "expected the plus operation to work");
        }

        [TestMethod]
        public void MapperTest()
        {
            // Arrange
            Mapper mapper = new Mapper();

            Patch testPatch = new Patch()
            {
                Id = 1,
                Crop = "TestCrop",
                GardenId = 5,
                PatchName = "TestPatch"
            };

            // Act
            PatchVM resultPatchVM = mapper.ToVM(testPatch);

            // Assert
            Assert.AreEqual(testPatch.Id, resultPatchVM.Id, "expected ID's to be the same");
            Assert.AreEqual(testPatch.GardenId, resultPatchVM.GardenId, "expected GardenId's to be the same");
            Assert.AreEqual(testPatch.Crop, resultPatchVM.Crop, "expected cropname's to be the same");
            Assert.AreEqual(testPatch.PatchName, resultPatchVM.PatchName, "expected patchname's to be the same");
        }

        [TestMethod]
        public void PatchTaskMapperTest()
        {
            // Arrange
            Mapper mapper = new Mapper();
            PatchTask testPatchTask = new PatchTask()
            {
                Id = 1,
                PatchId = 2,
                TaskName = "testTaskName",
                TaskDescription = "testTaskDescription"
            };

            // Act
            PatchTaskVM patchTaskVM = mapper.ToVM(testPatchTask);

            // Assert
            Assert.AreEqual(patchTaskVM.Id, testPatchTask.Id, "PatchTaskId's are expected to be equal");
            Assert.AreEqual(patchTaskVM.PatchId, testPatchTask.PatchId, "PatchId's are expected to be equal");
            Assert.AreEqual(patchTaskVM.TaskName, testPatchTask.TaskName, "Tasknames are expected to be equal");
            Assert.AreEqual(patchTaskVM.TaskDescription, testPatchTask.TaskDescription, "Task descriptions are expected to be equal");
        }




        

       /* [TestMethod]
        public void GardenMapperTest()
        {
            // Arrange
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


            Mapper mapper = new Mapper();
            

            // Act
            GardenVM gardenVM = mapper.ToVM(garden);

            // Assert
            Assert.AreEqual(gardenVM.Id, garden.Id, "Id's are expected to be equal");
            Assert.AreEqual(gardenVM.Name, garden.Name, "Garden names are expected to be equal");
            Assert.AreEqual(gardenVM.Location, garden.Location, "Location names are expected to be equal");
            CollectionAssert.AreEqual(gardenVM.Patches, (ICollection)garden.Patches, "Patches are expected to be equal");
            CollectionAssert.AreEqual(gardenVM.Users, actual: garden.GardenUsers, "GardenUsers are expected to be equal");
            Assert.AreEqual(gardenVM.GardenImageId, garden.GardenImageId, "ImageId's are expected to be equal");
            //CollectionAssert.AllItemsAreNotNull(garden.Patches);
            //Assert.AreEqual<List>(gardenVM.Patches, garden.Patches, "blabla");
*/

        }
    }
}
