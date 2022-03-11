global using GreenTeam.Utils;
using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
