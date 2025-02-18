using Microsoft.EntityFrameworkCore;

namespace EmployeeServiceApi.Models
{
    public class EmployeeDbContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
