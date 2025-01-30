using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dz_30._01.Controllers
{
    [Authorize(Policy = "FacultyPolicy")]
    public class ClosedController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Faculty = User.Claims.FirstOrDefault(c => c.Type == "Faculty")?.Value;
            return View();
        }
    }
}
