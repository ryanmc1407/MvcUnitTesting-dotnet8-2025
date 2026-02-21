using Microsoft.AspNetCore.Mvc;
using MvcUnitTesting_dotnet8.Models;
using System.Diagnostics;
using Tracker.WebAPIClient;
using DataLayer;

namespace MvcUnitTesting_dotnet8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository<Book> repository;

        public HomeController(IRepository<Book> bookRepo, ILogger<HomeController> logger)

        {
            ActivityAPIClient.Track(StudentID: "S00236888",
                StudentName: "Ryan McClelland", activityName: "Rad302 2026 Week 2 Lab 1",
                Task: "Running inital tests");

            repository = bookRepo;
            _logger = logger;
        }

        public IActionResult Index(string genre)
        {
           
            ViewData["Genre"] = genre;

            // View all books
            var books = repository.GetAll();

            // Filter if a genre is specified 
            if (!string.IsNullOrEmpty(genre))
            {
                books = books.Where(b => b.Genre == genre).ToList();   
            }
            return View(books);
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Your Privacy is our concern";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
