using Microsoft.AspNetCore.Mvc;
using MvcUnitTesting_dotnet8.Models;
using DataLayer;

public class BooksController : Controller
{
    private readonly IRepository<Book> _repository;

    public BooksController(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        // Fetches the seeded books from the database
        var books = _repository.GetAll();
        return View(books);
    }
}