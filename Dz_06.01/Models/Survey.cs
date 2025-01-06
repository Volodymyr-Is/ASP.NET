using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Dz_06._01.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be longer than 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [AgeRange(18, 99, ErrorMessage = "Age must be in range of 18 and 99")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Remote(action: "isAvailableEmail", controller: "Survey", ErrorMessage = "Email address already used")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Satisfaction level is required")]
        public string Satisfaction { get; set; }

        [Required(ErrorMessage = "Choose atleast 1 service")]
        public List<string> ServicesUsed { get; set; }

        [MaxLength(500, ErrorMessage = "Suggestions cant be longer than 500 characters")]
        public string Suggestions { get; set; }
    }
}
