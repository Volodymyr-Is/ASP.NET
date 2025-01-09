using System.Diagnostics;
using System.Text.Json;
using Dz_09._01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dz_09._01.Controllers
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
            var products = GetViewedProducts();
            return View(products);
        }

        public IActionResult Product(int id)
        {
            AddProductToCookie(id);
            return View(id);
        }

        private List<int> GetViewedProducts()
        {
            var cookie = Request.Cookies["ViewedProducts"];
            if (string.IsNullOrEmpty(cookie))
            {
                return new List<int>();
            }

            return JsonSerializer.Deserialize<List<int>>(cookie);
        }

        private void AddProductToCookie(int id)
        {
            var products = GetViewedProducts();

            if (!products.Contains(id))
            {
                products.Add(id);
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(7),
                };
                
                Response.Cookies.Append("ViewedProducts", JsonSerializer.Serialize(products), cookieOptions);
            }
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
