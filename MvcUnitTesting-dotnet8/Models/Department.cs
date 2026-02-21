using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace DataLayer
{
    [Table("Departments")]
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}