using CsvHelper;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MvcUnitTesting_dotnet8.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
              new Book { ID = 1, Name = "Moby Dick", Genre = "Fiction", Price = 12.50m },
              new Book { ID = 2, Name = "War and Peace", Genre = "Fiction", Price = 17.00m },
              new Book { ID = 3, Name = "Escape from the vortex", Genre = "Science Fiction", Price = 12.50m },
              new Book { ID = 4, Name = "The Battle of the Somme", Genre = "History", Price = 22.00m }
    );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        public static void SeedFromCsv(BookDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Departments.Any()) return;

            // 1. Seed Departments
            using (var reader = new StreamReader("Data/Departments.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Department>().ToList();
                context.Departments.AddRange(records);
                // SAVE NOW so IDs exist for the next step
                context.SaveChanges();
            }

            // 2. Seed Employees
            using (var reader = new StreamReader("Data/Employee.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
               
                var records = csv.GetRecords<Employee>()
                                 .Select(e => { e.Department = null; return e; })
                                 .ToList();

                context.Employees.AddRange(records);
                context.SaveChanges();
            }
        }
    }
}
