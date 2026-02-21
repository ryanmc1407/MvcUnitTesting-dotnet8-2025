using DataLayer;
using Microsoft.AspNetCore.Mvc;
using MvcUnitTesting_dotnet8.Models;

public class DepartmentController : Controller
{
    private readonly IRepository<Department> _repository;

    public DepartmentController(IRepository<Department> repository)
    {
        _repository = repository;
    }

    public IActionResult Index(string deptName) // Must match the dropdown name attribute
    {
        // Save the selection so the view can see it
        ViewBag.SelectedDept = deptName;
        // 1. Fetch the department including employees
        var department = _repository.Find(d => d.Name == deptName).FirstOrDefault();

        // 2. Pass the employees as the model
        var employees = department?.Employees ?? new List<Employee>();
        return View(employees);
    }
}