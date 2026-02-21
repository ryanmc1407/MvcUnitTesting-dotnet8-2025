using Microsoft.EntityFrameworkCore;

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
    }
}
