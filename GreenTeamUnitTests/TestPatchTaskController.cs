using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreenTeamUnitTests
{
    /*[TestClass]
    public class TestPatchTaskController
    {
        [TestMethod]
        public async void PostPatchTaskCreateSuccesfull()
        {
            // Arrange
            PatchTask patchTask = new PatchTask() { Id = 2, PatchId = 1, TaskDescription = "testTaskDescription", TaskName = "testTaskName" };

            var mockIPatchTaskService = new Mock<IPatchTaskService>();
            mockIPatchTaskService.Setup(q => q.AddPatchTask(patchTask).Result).Returns(patchTask);
            Mapper mapper = new Mapper();

            PatchTasksController controller = new PatchTasksController((IPatchTaskService)mockIPatchTaskService, mapper);

            // Act
            var returnedType = await controller.Create(patchTask);

            // Assert
            //Assert.IsNotNull(returnedType);
            Assert.AreEqual(patchTask, returnedType);        

        }

        public async void PatchTaskEditSuccesfull()
        {
            PatchTask patchTask = new PatchTask() { Id = 1, PatchId = 1, TaskDescription = "testTaskDescription", TaskName = "testTaskName" };

            var mockIPatchTaskService = new Mock<IPatchTaskService>();
            mockIPatchTaskService.Setup(controller => controller.FindById(1).Result).Returns(patchTask);
            *//*var mockIPatchTaskService = new Mock<IPatchTaskService>();
            mockIPatchTaskService.Setup(controller => controller.FindById().Result.);*//*
        }
    }*/
}
