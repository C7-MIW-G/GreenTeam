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
    }
}