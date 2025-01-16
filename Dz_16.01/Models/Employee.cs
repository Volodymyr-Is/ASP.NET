using System.ComponentModel.DataAnnotations;

namespace Dz_16._01.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Surname { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary cannot be less than 0")]
        public decimal Salary { get; set; }
    }
}
