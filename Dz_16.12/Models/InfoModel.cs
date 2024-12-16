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
        public int InfoId { get; set; }
        public string SkillDescription { get; set; }
    }

    public class TestQuestionModel
    {
        public int Id { get; set; }
        public int InfoId { get; set; }
        public int QuestionNumber { get; set; }
        public string Answer { get; set; }
    }

    public class SummaryViewModel
    {
        public InfoModel Info { get; set; }
        public SkillsModel Skills { get; set; }
        public TestQuestionModel TestQuestion { get; set; }
    }
}
