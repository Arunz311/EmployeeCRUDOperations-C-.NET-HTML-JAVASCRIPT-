using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRecords.Data;
using EmployeeRecords.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecords.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public IList<Employee> Employees { get; set; }
        public decimal TotalSalary { get; set; }


        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            if (Employee.Id == 0) // New employee
            {
                _context.Employees.Add(Employee);
            }
            else // Existing employee
            {
                var existingEmployee = await _context.Employees.FindAsync(Employee.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.Name = Employee.Name;
                    existingEmployee.Designation = Employee.Designation;
                    existingEmployee.DateOfJoining = Employee.DateOfJoining;
                    existingEmployee.Salary = Employee.Salary;
                    existingEmployee.Gender = Employee.Gender;
                    existingEmployee.State = Employee.State;

                    _context.Employees.Update(existingEmployee);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage(); // Redirect to the same page to refresh the list
        }
        public async Task<IActionResult> OnPostSumSalaryAsync()
        {
            try
            {
                // Fetch the total salary
                var totalSalary = await _context.Employees.SumAsync(e => e.Salary);

                // Return the total salary as JSON
                return new JsonResult(new { totalSalary });
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                Console.WriteLine(ex.Message);
                return new JsonResult(new { error = "An error occurred while calculating the total salary." });
            }
        }


    }
}

