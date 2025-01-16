using System.ComponentModel.DataAnnotations;

namespace Dz_16._01.Models
{
    public class ErrorLogger
    {
        public int Id { get; set; }

        [Required]
        public string ErrorDetails { get; set; } = null!;

        public DateTime LogDate { get; set; }
    }
}
