using Microsoft.EntityFrameworkCore;
using EmployeeRecords.Models; // Update with the correct namespace

namespace EmployeeRecords.Data // Update with the correct namespace
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
