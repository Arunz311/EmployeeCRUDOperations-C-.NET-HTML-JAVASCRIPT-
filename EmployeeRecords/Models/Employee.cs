// Models/Employee.cs
using System.ComponentModel.DataAnnotations;

namespace EmployeeRecords.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Designation { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salary is Required")]
        public decimal Salary { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string State { get; set; }

    }
}
