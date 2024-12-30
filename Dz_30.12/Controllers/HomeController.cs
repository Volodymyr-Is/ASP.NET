using System.Diagnostics;
using Dz_30._12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dz_30._12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Register(FormModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
