using Dz_06._01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dz_06._01.Controllers
{
    public class SurveyController : Controller
    {
        private static readonly List<Survey> Surveys = new List<Survey>();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Survey survey)
        {
            if (ModelState.IsValid)
            {
                Surveys.Add(survey);
                return RedirectToAction("Success");
            }
            return View(survey);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult isAvailableEmail(string email)
        {
            var exists = Surveys.Any(s => s.Email == email);
            return Json(!exists);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
