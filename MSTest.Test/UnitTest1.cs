using DataLayer;
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

            // Act  
            var result = controller.Index("Science Fiction") as ViewResult;

            // Assert
            Assert.AreEqual(expectedGenre, result.ViewData["Genre"]);
        }
        [TestMethod]
        public void test_book_by_genre()
        {
            // Arrange
            var mockRepo = Telerik.JustMock.Mock.Create<IRepository<Book>>();
            var mockLogger = Telerik.JustMock.Mock.Create<ILogger<HomeController>>();

            var books = new List<Book>
            {
                 new Book { Name = "Sci-Fi Book", Genre = "Science Fiction" },
                 new Book { Name = "History Book", Genre = "History" }
             };

            Telerik.JustMock.Mock.Arrange(() => mockRepo.GetAll()).Returns(books);
            var controller = new HomeController(mockRepo, mockLogger);

            // Act
            var viewResult = controller.Index("Science Fiction") as ViewResult;
            var model = viewResult.Model as IEnumerable<Book>;

            // Assert
            Assert.AreEqual(1, model.Count());
        }

        [TestMethod]
        public void test_employees_by_department()
        {
            // Arrange
            var mockRepo = Telerik.JustMock.Mock.Create<IRepository<Department>>();

            // Create a department with some employees
            var dept = new Department { Name = "IT", = 1 };
            var employees = new List<Employee>
             {
              new Employee { Name = "Alice", DepartmentID = 1, Department = dept },
              new Employee { Name = "Bob", DepartmentID = 2 } // Different dept
             };
            dept.Employees = employees.Where(e => e.DepartmentID == 1).ToList();

            // Mock the repository to return this department
            Telerik.JustMock.Mock.Arrange(() => mockRepo.GetAll())
                .Returns(new List<Department> { dept });

            var controller = new DepartmentController(mockRepo);

            // Act
            var viewResult = controller.Index("IT") as ViewResult;
            var model = viewResult.Model as IEnumerable<Employee>;

            // Assert
            Assert.AreEqual(1, model.Count());
            Assert.AreEqual("Alice", model.First().Name);
        }


    }
}