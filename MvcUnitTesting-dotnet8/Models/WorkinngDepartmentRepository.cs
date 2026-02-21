using DataLayer;
using Microsoft.EntityFrameworkCore;
using MvcUnitTesting_dotnet8.Models;
using System.Linq.Expressions;

public class WorkingDepartmentRepository : IRepository <Department>
{
    private readonly BookDbContext _context;

    public WorkingDepartmentRepository(BookDbContext context)
    {
        _context = context;
    }

    public void Add(Department entity)
    {
        throw new NotImplementedException();
    }

    public void AddRange(IEnumerable<Department> entities)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Department> Find(Expression<Func<Department, bool>> predicate)
    {
        // Use .Where instead of .FirstOrDefault to return a list
        return _context.Departments
                       .Include(d => d.Employees)
                       .Where(predicate)
                       .ToList();
    }

    // This is the missing method causing your error
    public Department Get(int id)
    {
        return _context.Departments.Find(id);
    }

    public IEnumerable<Department> GetAll()
    {
        // Use .Include to ensure Employees are loaded from the database
        return _context.Departments.Include(d => d.Employees).ToList();
    }

    public void Remove(Department entity)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<Department> entities)
    {
        throw new NotImplementedException();
    }
}