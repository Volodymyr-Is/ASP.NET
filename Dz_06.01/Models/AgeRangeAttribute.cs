using System.ComponentModel.DataAnnotations;

namespace Dz_06._01.Models
{
    public class AgeRangeAttribute: ValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;

        public AgeRangeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int age)
            {
                if (age >= _min && age <= _max)
                    return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage ?? $"Age must be in range of {_min} and {_max}");
        }
    }
}
