using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeamUnitTests
{
    [TestClass]
    public class TestPatchTaskMapper
    {
        private PatchTask CreateFakePatchTask()
        {
            var patchTask = new PatchTask()
            {
                Id = 1,
                PatchId = 1,
                TaskName = "taskName",
                TaskDescription = "taskDescription",
                IsDeleted = false,
                IsCompleted = false            
            };

            return patchTask;
        }

        [TestMethod]
        public void Test_PatchTaskVM_ContainsIdProperty()
        {
            // Arrange
            Mapper mapper = new Mapper();
            var patchTask = CreateFakePatchTask();

            // Act
            var patchTaskVM = mapper.ToVM(patchTask);

            // Assert
            Assert.AreEqual(patchTaskVM.Id, patchTask.Id, "PatchTask id's are expected to be equal");
        }

        [TestMethod]
        public void Test_PatchTaskVM_ContainsPatchId()
        {
            // Arrange
            Mapper mapper = new Mapper();
            var patchTask = CreateFakePatchTask();

            // Act
            var patchTaskVM = mapper.ToVM(patchTask);

            // Assert
            Assert.AreEqual(patchTaskVM.PatchId, patchTask.PatchId, "PatchTask patchId's are expexted to be equal");
        }

        [TestMethod]
        public void Test_PatchTaskVM_ContainsTaskName()
        {
            // Arrange
            Mapper mapper = new Mapper();
            var patchTask = CreateFakePatchTask();

            // Act
            var patchTaskVM = mapper.ToVM(patchTask);

            // Assert
            Assert.AreEqual(patchTaskVM.TaskName, patchTask.TaskName, "PatchTask task names are expected to be equal");
        }

        [TestMethod]
        public void Test_PatchTaskVM_ContainsTaskDescription()
        {
            // Arrange
            Mapper mapper = new Mapper();
            var patchTask = CreateFakePatchTask();

            // Act
            var patchTaskVM = mapper.ToVM(patchTask);

            // Assert
            Assert.AreEqual(patchTaskVM.TaskDescription, patchTask.TaskDescription, "PatchTask task names are expected to be equal");
        }


        [TestMethod]
        public void Test_PatchTaskVM_BooleanIsEqual()
        {
            // Arrange
            Mapper mapper = new Mapper();
            var patchTask = CreateFakePatchTask();

            // Act
            var patchTaskVM = mapper.ToVM(patchTask);

            // Assert
            Assert.AreEqual(patchTaskVM.IsDeleted, patchTask.IsDeleted, "PatchTask task names are expected to be equal");
        }
    }
}
