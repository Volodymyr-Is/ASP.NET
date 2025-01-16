using Dz_16._01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dz_16._01.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MyDBContext _context;

        public EmployeeController(MyDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid) 
                return View(employee);

            if(employee.Salary < 0)
            {
                ModelState.AddModelError("Salary", "Employee salary cannot be less than 0...");
                return View(employee);
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();

            ViewBag.Message = "Employee created successfully...";
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
