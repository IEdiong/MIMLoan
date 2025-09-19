using System.ComponentModel.DataAnnotations;

namespace MimLoan.Web.Validations;

public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
        ErrorMessage = $"You must be at least {_minimumAge} years old.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime dateOfBirth)
        {
            if (dateOfBirth.AddYears(_minimumAge) > DateTime.Today)
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}