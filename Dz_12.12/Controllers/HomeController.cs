using System.Diagnostics;
using Dz_16._12.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dz_16._12.Controllers
{
    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    private static readonly List<string> Questions = new()
    //    {
    //        "Question1",
    //        "Question2",
    //        "Question3",
    //        "Question4",
    //        "Question5"
    //    };

    //    private static List<TestQuestionModel> _testResults = new();

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    [HttpGet]
    //    public IActionResult PersonalInfo()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public IActionResult PersonalInfo(InfoModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            TempData["PersonalInfo"] = JsonConvert.SerializeObject(model);
    //            return RedirectToAction("Skills");
    //        }
    //        return View(model);
    //    }

    //    [HttpGet]
    //    public IActionResult Skills()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public IActionResult Skills(SkillsModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            TempData["Skills"] = JsonConvert.SerializeObject(model);
    //            return RedirectToAction("Tests", new { questionIndex = 0 });
    //        }

    //        return View(model);
    //    }

    //    [HttpGet]
    //    public IActionResult Tests(int questionIndex)
    //    {
    //        if (questionIndex >= Questions.Count)
    //        {
    //            TempData["TestResults"] = _testResults;
    //            return RedirectToAction("Summary");
    //        }

    //        ViewData["QuestionNumber"] = questionIndex + 1;
    //        ViewData["Question"] = Questions[questionIndex];
    //        return View();
    //    }


    //    [HttpPost]
    //    public IActionResult Tests(TestQuestionModel model, int questionIndex)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _testResults.Add(new TestQuestionModel
    //            {
    //                QuestionNumber = questionIndex + 1,
    //                Question = Questions[questionIndex],
    //                Answer = model.Answer
    //            });

    //            return RedirectToAction("Tests", new { questionIndex = questionIndex + 1 });
    //        }

    //        ViewData["QuestionNumber"] = questionIndex + 1;
    //        ViewData["Question"] = Questions[questionIndex];
    //        return View(model);
    //    }

    //    [HttpGet]
    //    public IActionResult Summary()
    //    {
    //        var personalInfoJson = TempData["PersonalInfo"] as string;
    //        var skillsJson = TempData["Skills"] as string;

    //        ViewData["PersonalInfo"] = string.IsNullOrEmpty(personalInfoJson)
    //            ? null
    //            : JsonConvert.DeserializeObject<InfoModel>(personalInfoJson);

    //        ViewData["Skills"] = string.IsNullOrEmpty(skillsJson)
    //            ? null
    //            : JsonConvert.DeserializeObject<SkillsModel>(skillsJson);

    //        ViewData["TestResults"] = _testResults;
    //        return View();
    //    }

    //    [HttpPost]
    //    public IActionResult Confirm()
    //    {
    //        return RedirectToAction("Index", "Home");
    //    }
    //}


    public class HomeController : Controller
    {
        private readonly MyDbContext _context;

        private static readonly List<string> Questions = new()
        {
            "Question1",
            "Question2",
            "Question3",
            "Question4",
            "Question5"
        };

        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult PersonalInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonalInfo(InfoModel model)
        {
            if (ModelState.IsValid)
            {
                _context.PersonalInfos.Add(model);
                _context.SaveChanges();
                TempData["PersonalInfoId"] = model.Id;
                return RedirectToAction("Skills");
            }
            return View(model);
        }

        public IActionResult Skills()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Skills(SkillsModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Skills.Add(model);
                _context.SaveChanges();
                TempData["SkillsId"] = model.Id;
                return RedirectToAction("Tests", new { questionIndex = 0 });
            }
            return View(model);
        }

        public IActionResult Tests(int questionIndex)
        {
            if (questionIndex >= Questions.Count)
            {
                return RedirectToAction("Summary");
            }

            ViewData["QuestionNumber"] = questionIndex + 1;
            ViewData["Question"] = Questions[questionIndex];
            return View();
        }

        [HttpPost]
        public IActionResult Tests(TestQuestionModel model, int questionIndex)
        {
            if (ModelState.IsValid)
            {
                model.QuestionNumber = questionIndex + 1;
                model.Question = Questions[questionIndex];
                _context.TestResults.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Tests", new { questionIndex = questionIndex + 1 });
            }

            ViewData["QuestionNumber"] = questionIndex + 1;
            ViewData["Question"] = Questions[questionIndex];
            return View(model);
        }

        public IActionResult Summary()
        {
            int personalInfoId = Convert.ToInt32(TempData["PersonalInfoId"]);
            int skillsId = Convert.ToInt32(TempData["SkillsId"]);

            var personalInfo = _context.PersonalInfos.FirstOrDefault(p => p.Id == personalInfoId);
            var skills = _context.Skills.FirstOrDefault(s => s.Id == skillsId);
            var testResults = _context.TestResults.ToList();

            var summaryModel = new SummaryModel
            {
                PersonalInfo = personalInfo,
                Skills = skills,
                TestResults = testResults
            };

            return View(summaryModel);
        }

        [HttpPost]
        public IActionResult Confirm()
        {
            return RedirectToAction("Index", "Home");
        }
    }

}
