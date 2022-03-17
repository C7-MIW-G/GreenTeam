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
    public class TestPatchTaskController
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

        public Patch createTestPatch()
        {
            Patch patch = new Patch()
            {
                Id = 1,
                GardenId = 42,
                Crop = "testCrop",
                PatchName = "testPatchName",

            };

           return patch;
        }

        public PatchTask createTestPatchTask()
        {
            PatchTask patchTask = new PatchTask()
            { 
                Id = 23, 
                PatchId = 34, 
                TaskDescription = "testTaskDescription", 
                TaskName = "testTaskName" 
            };

            return patchTask;
        }

        public PatchTaskVM createPatchTaskVM()
        {
            PatchTaskVM patchTaskVM = new PatchTaskVM()
            { 
                Id = 23, 
                PatchId = 34, 
                TaskDescription = "testTaskDescription", 
                TaskName = "testTaskName" 
            };
           
            return patchTaskVM;
        }

        [TestMethod]
        public void PostPatchTaskCreateSuccesfull()
        {
            // Arrange
            Garden garden = createTestGarden();
            Patch patch = createTestPatch();         
            PatchTask patchTask = createTestPatchTask();
            PatchTaskVM patchTaskVM = createPatchTaskVM();

            var mockIGardenService = new Mock<IGardenService>();
            mockIGardenService.Setup(x => x.FindById(garden.Id).Result).Returns(garden);

            var mockIPatchService = new Mock<IPatchService>();
            mockIPatchService.Setup(x => x.FindById(patch.Id).Result).Returns(patch);
            
            var mockIPatchTaskService = new Mock<IPatchTaskService>();
            mockIPatchTaskService.Setup(q => q.AddPatchTask(patchTask).Result).Returns(patchTask);
            Mapper mapper = new Mapper();

            var controller = new PatchTasksController(mockIPatchService.Object, 
                mockIPatchTaskService.Object, mockIGardenService.Object, mapper);

      

            // Act
            var actionResult = controller.Create(patchTask);

            ViewResult actionViewResult = (ViewResult)actionResult.Result;
            PatchTaskVM actualModel = actionViewResult.Model as PatchTaskVM;


            // Assert
            //Assert.IsNotNull(returnedType);
            Assert.AreSame(patchTaskVM, actualModel, "Both return same Model View");
           /* Assert.AreEqual(patchTaskVM, actualModel, "Fuck Testing");
*/
        }
    }
}
