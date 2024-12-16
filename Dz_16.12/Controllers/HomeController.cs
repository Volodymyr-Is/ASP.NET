using System.Diagnostics;
using Dz_16._12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dz_16._12.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
