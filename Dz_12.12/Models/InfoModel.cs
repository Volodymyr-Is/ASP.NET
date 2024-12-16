using Microsoft.AspNetCore.Mvc;

namespace Dz_16._12.Models
{
    public class InfoModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        public string ContactInfo { get; set; }
    }

    public class SkillsModel
    {
        public int Id { get; set; }
        public string SkillsDescription { get; set; }
    }

    public class TestQuestionModel
    {
        public int Id { get; set; }
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    public class SummaryModel
    {
        public InfoModel PersonalInfo { get; set; }
        public SkillsModel Skills { get; set; }
        public List<TestQuestionModel> TestResults { get; set; }
    }
}
