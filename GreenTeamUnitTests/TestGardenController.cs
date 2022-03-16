using GreenTeam.Controllers;
using GreenTeam.Implementations;
using GreenTeam.Models;
using GreenTeam.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GreenTeamUnitTests
{
    [TestClass]
    public class TestGardenController
    {
        public Garden createTestGarden()
        {
            Garden garden = new Garden()
            {
                Id = 42,
                Name = "TestGarden",
                Location = "TestLocation",
                ImageId = 4242,
                Patches = null
            };
            return garden;
        }
        public GardenVM createTestGardenVM()
        {
            GardenVM vm = new GardenVM()
            {
                Id = 42,
                Name = "TestGarden",
                Location = "TestLocation",
                ImageId = 4242,
                Patches = new List<PatchVM>
                {
                    new PatchVM()
                    {
                        Id = 23, PatchName = "TestLocation", Crop = "TestCrop", GardenId = 42
                    },
                    new PatchVM()
                    {
                        Id = 32, PatchName = "TestLocation2", Crop = "TestCrop2", GardenId = 42
                    }
                },
                Users = new List<AppUserVM>(),
                Image = new Image() {}
                
            };
            return vm;
        }

        [TestMethod]
        public void TestEditGardenGet()
        {
            //Arrange
            GardenVM gardenVM = createTestGardenVM();
            var mockGardenService = new Mock<IGardenService>();
            mockGardenService.Setup(x => x.GetVMById(gardenVM.Id)).ReturnsAsync(gardenVM);
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(y => y.IsAuthorizedToAccessGarden(gardenVM.Id)).ReturnsAsync(true);
            var controller = new GardensController(mockGardenService.Object, mockUserService.Object, null, null, null);

            //Act
            var actionResult = controller.Edit(gardenVM.Id);

            ViewResult actionViewResult = (ViewResult)actionResult.Result; //Unpackaging
            GardenVM actualModel = actionViewResult.Model as GardenVM; //Unpackaging

            //Assert           
            Assert.AreSame(gardenVM, actualModel, "Models are not the same.");
        }
        
       
    }
}
