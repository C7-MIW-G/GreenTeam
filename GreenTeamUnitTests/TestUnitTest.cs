using GreenTeam.Models;
using GreenTeam.Services;
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
    }
}