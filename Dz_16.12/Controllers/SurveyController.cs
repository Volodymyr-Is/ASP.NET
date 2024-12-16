using Dz_16._12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dz_16._12.Controllers
{
    public class SurveyController : Controller
    {
        private readonly MyDbContext _context;

        public SurveyController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult PersonalInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonalInfo(string firstName, string lastName, int age, string specialization, string contactInfo)
        {
            var personalInfo = new InfoModel
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Specialization = specialization,
                ContactInfo = contactInfo
            };

            _context.PersonalInfos.Add(personalInfo);
            _context.SaveChanges();

            return RedirectToAction("Skills");
        }

        [HttpGet]
        public IActionResult Skills()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Skills(string skillsDescription)
        {
            var skills = new SkillsModel
            {
                SkillDescription = skillsDescription
            };

            _context.Skills.Add(skills);
            _context.SaveChanges();

            return RedirectToAction("Tests");
        }

        [HttpGet]
        public IActionResult Tests()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tests(string testAnswer)
        {
            var testResult = new TestQuestionModel
            {
                Answer = testAnswer
            };

            _context.TestResults.Add(testResult);
            _context.SaveChanges();

            return RedirectToAction("Summary");
        }

        [HttpGet]
        public IActionResult Summary()
        {
            var summaryViewModel = new SummaryViewModel
            {
                Info = new InfoModel
                {
                    FirstName = _context.PersonalInfos.OrderByDescending(x => x.Id).FirstOrDefault()?.FirstName,
                    LastName = _context.PersonalInfos.OrderByDescending(x => x.Id).FirstOrDefault()?.LastName,
                    Age = _context.PersonalInfos.OrderByDescending(x => x.Id).FirstOrDefault()?.Age ?? 0,
                    Specialization = _context.PersonalInfos.OrderByDescending(x => x.Id).FirstOrDefault()?.Specialization,
                    ContactInfo = _context.PersonalInfos.OrderByDescending(x => x.Id).FirstOrDefault()?.ContactInfo
                },
                Skills = new SkillsModel
                {
                    SkillDescription = _context.Skills.OrderByDescending(x => x.Id).FirstOrDefault()?.SkillDescription
                },
                TestQuestion = new TestQuestionModel
                {
                    Answer = _context.TestResults.OrderByDescending(x => x.Id).FirstOrDefault()?.Answer
                }
            };

            return View(summaryViewModel);
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Summary(SummaryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var personalInfo = new InfoModel
                {
                    FirstName = model.Info.FirstName,
                    LastName = model.Info.LastName,
                    Age = model.Info.Age,
                    Specialization = model.Info.Specialization,
                    ContactInfo = model.Info.ContactInfo
                };

                _context.PersonalInfos.Add(personalInfo);
                _context.SaveChanges();

                int infoId = personalInfo.Id;

                var skills = new SkillsModel
                {
                    InfoId = infoId,
                    SkillDescription = model.Skills.SkillDescription
                };

                _context.Skills.Add(skills);

                var testResult = new TestQuestionModel
                {
                    InfoId = infoId,
                    QuestionNumber = model.TestQuestion.QuestionNumber,
                    Answer = model.TestQuestion.Answer
                };

                _context.TestResults.Add(testResult);

                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}

