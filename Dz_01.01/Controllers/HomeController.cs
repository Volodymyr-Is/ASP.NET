using System.Diagnostics;
using Dz_01._01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dz_01._01.Controllers
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
    }
}
