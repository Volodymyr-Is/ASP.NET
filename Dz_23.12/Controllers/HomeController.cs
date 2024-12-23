using System.Diagnostics;
using Dz_23._12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dz_23._12.Controllers
{
    public class HomeController : Controller
    {
        private List<Employee> employees;
        private List<Department> departments;

        public HomeController()
        {
            departments = new List<Department> { 
                new Department{ Id = 1, Name = "IT" },
                new Department{ Id = 2, Name = "Finance" },
                new Department{ Id = 3, Name = "HR" },
            };

            employees = new List<Employee> { 
                new Employee{ Id = 1, Name = "John", DepartmentId = 1 },
                new Employee{ Id = 2, Name = "Emily", DepartmentId = 2 },
                new Employee{ Id = 3, Name = "Robert", DepartmentId = 3 },
                new Employee{ Id = 4, Name = "Jane", DepartmentId = 1 },
            };
        }

        public IActionResult Index()
        {
            var employeeViewModel = employees.Join(departments, 
                e => e.DepartmentId, 
                d => d.Id, 
                (e, d) => new EmployeeViewModel { EmployeeId = e.Id, EmployeeName = e.Name, DepartmentName = d.Name, DepartmentId = d.Id }).ToList();

            return View(employeeViewModel);
        }

        public IActionResult Department(int departmentId)
        {
            var employeeViewModel = employees.Where(e => e.DepartmentId == departmentId).Join(departments,
                e => e.DepartmentId, 
                d => d.Id, 
                (e, d) => new EmployeeViewModel { EmployeeId = e.Id, EmployeeName = e.Name, DepartmentName = d.Name, DepartmentId = d.Id }).ToList();

            return View("Index", employeeViewModel);
        }
    }
}
