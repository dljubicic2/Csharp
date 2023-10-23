using System.ComponentModel.DataAnnotations;

namespace EdunovaWP1.Validations
{
    public class NadimakNeMozeBitiBroj : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
			try
			{
				var broj = decimal.Parse((string)value);
				return new ValidationResult("Nadimak ne može biti broj");
			}
			catch (Exception e)
			{

				
			}
			return ValidationResult.Success;
        }
    }
}
