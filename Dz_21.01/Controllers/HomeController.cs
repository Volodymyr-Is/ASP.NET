using System.Diagnostics;
using System.Text.Json;
using Dz_21._01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dz_21._01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDistributedCache _cache;
        public HomeController(ILogger<HomeController> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            string cacheKey = "SomeData";
            string cacheData = await _cache.GetStringAsync(cacheKey);

            if (string.IsNullOrEmpty(cacheData))
            {
                var data = GetData();

                await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(data), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
            }

            var result = JsonSerializer.Deserialize<List<string>>(cacheData);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateData()
        {
            string cacheKey = "SomeData";
            await _cache.RemoveAsync(cacheKey);

            var updatedData = UpdatedData();
            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(updatedData), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });

            return RedirectToAction("Index");
        }

        private List<string> GetData()
        {
            return new List<string> { "Data1", "Data2", "Data3" };
        }

        private List<string> UpdatedData()
        {
            return new List<string> { "UpdatedData1", "UpdatedData2", "UpdatedData3" };
        }
    }
}
