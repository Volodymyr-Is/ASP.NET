namespace Dz_30._12.Models
{
    public class FormModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public List<string> Hobbies { get; set; } = new List<string>();
        public string Course { get; set; }
        public List<string> Skills { get; set; } = new List<string>();
    }
}
