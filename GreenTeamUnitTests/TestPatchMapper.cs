using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GreenTeamUnitTests
{
    [TestClass]
    public class TestPatchMapper
    {
        private Patch CreateFakePatch()
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

            return patch;
        }

        [TestMethod]
        public void PatchVMContainsIdProperty()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Patch patch = CreateFakePatch();

            // Act
            PatchVM patchVM = mapper.ToVM(patch);

            // Assert
            Assert.AreEqual(patchVM.Id, patch.Id, "Patch id's are expected to be equal");
        }

        [TestMethod]
        public void PatchVMContainsPatchName()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Patch patch = CreateFakePatch();

            // Act
            PatchVM patchVM = mapper.ToVM(patch);

            // Assert
            Assert.AreEqual(patchVM.PatchName, patch.PatchName, "Patchnames are expected to be equal");
        }

        [TestMethod]
        public void GardenVMContainsCrop()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Patch patch = CreateFakePatch();

            // Act
            PatchVM patchVM = mapper.ToVM(patch);

            // Assert
            Assert.AreEqual(patchVM.Crop, patch.Crop, "Patch crop's are expected to be equal");
        }

        [TestMethod]
        public void PatchVMContainsGardenId()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Patch patch = CreateFakePatch();

            // Act
            PatchVM patchVM = mapper.ToVM(patch);

            // Assert
            Assert.AreEqual(patchVM.GardenId, patch.GardenId, "GardenId's are expected to be equal");
        }

        /* Check if loop for adding PatchTasks to PatchTaskList works*/
        [TestMethod]
        public void GardenVMContainsPatchListWithPatchTasks()
        {
            // Arrange
            Mapper mapper = new Mapper();
            Patch patch = CreateFakePatch();
            List<PatchTask> patchTaskList = patch.PatchTasks.ToList();

            // Act
            PatchVM patchVM = mapper.ToVM(patch);

            // Assert
            Assert.AreEqual(patchVM.PatchTasks[0].TaskName, patchTaskList[0].TaskName, "Tasknames are expected to be equal ");
            Assert.AreEqual(patchVM.PatchTasks[0].Id, patchTaskList[0].Id, "PatchTaskId's are expected to be equal");
        }
    }
}
