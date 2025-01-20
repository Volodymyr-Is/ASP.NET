using System.Diagnostics;
using Dz_20._01.Infrastucture;
using Dz_20._01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dz_20._01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [UniqueUsersCountFilter]
        public IActionResult Index()
        {
            int count = UniqueUsersCountFilterAttribute.GetUniqueUserCount();

            ViewBag.Count = count;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
