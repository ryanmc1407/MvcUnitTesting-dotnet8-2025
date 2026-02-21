using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcUnitTesting_dotnet8.Controllers;
using MvcUnitTesting_dotnet8.Models;

namespace MSTest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void show_ViewData_genre_test()
        {
            // Arrange
            var mockRepo = Telerik.JustMock.Mock.Create<IRepository<Book>>();
            var mockLogger = Telerik.JustMock.Mock.Create<ILogger<HomeController>>();
            var controller = new HomeController(mockRepo, mockLogger);
            string expectedGenre = "Science Fiction";

            // Act - This will cause a compiler error or fail until we update the Controller
            var result = controller.Index("Science Fiction") as ViewResult;

            // Assert
            Assert.AreEqual(expectedGenre, result.ViewData["Genre"]);
        }
    }
}