using GreenTeam.Controllers;
using GreenTeam.Implementations;
using GreenTeam.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeamUnitTests
{
    internal class PatchTaskControllerTest
    {
        public async void PostPatchTaskCreateSuccesfull()
        {
            //Arrage
            PatchTask patchTask = new PatchTask() { Id = 1, PatchId = 1, TaskDescription = "testTaskDescription", TaskName = "testTaskName" };

            var mockIPatchTaskService = new Mock<IPatchTaskService>();
            mockIPatchTaskService.Setup(controller => controller.AddPatchTask(patchTask).Result).Returns(patchTask);


            PatchTasksController controller = new PatchTasksController(null, null);

            // Act
            var returnedType = await controller.Create(patchTask);

            //var patchTaskSevice = mock.Setup(p => p.FindById(1).Result).Returns(new PatchTask() { Id = 1, PatchId = 1, TaskDescription = "testTaskDescription", TaskName = "testTaskName" });


            //Assert
            // Assert.That.GetType(returnedPatchTask, PatchTask);
            Assert.IsNotNull(returnedType);


        }

        /*public async void PatchTaskEditSuccesfull()
        {
            PatchTask patchTask = new PatchTask() { Id = 1, PatchId = 1, TaskDescription = "testTaskDescription", TaskName = "testTaskName" };

            var mockIPatchTaskService = new Mock<IPatchTaskService>();
            mockIPatchTaskService.Setup(controller => controller.FindById(1).Result).Returns(patchTask);
            *//*var mockIPatchTaskService = new Mock<IPatchTaskService>();
            mockIPatchTaskService.Setup(controller => controller.FindById().Result.);*//*
        }*/

    }
}
