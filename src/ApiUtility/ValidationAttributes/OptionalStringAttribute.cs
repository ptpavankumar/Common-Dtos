using System.ComponentModel.DataAnnotations;

namespace ApiUtility.ValidationAttributes
{
    public class OptionalStringAttribute : ValidationAttribute
    {
        public long MaxLength { get; set; }
        public long MinLength { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null) return ValidationResult.Success;

            var strValue = value.ToString().Trim();
            var maxLength = MaxLength != 0 ? MaxLength : long.MaxValue;

            if (string.IsNullOrEmpty(strValue) || (strValue.Length >= MinLength && strValue.Length <= maxLength))
                return ValidationResult.Success;

            if (ErrorMessage != null)
                return new ValidationResult(ErrorMessage);

            var error = $"The field {validationContext.MemberName} ";

            if (MinLength != 0 && MaxLength != 0)
                error += $"must be a string with a minimum length of {MinLength} and maximum length of {MaxLength}.";
            else if (MinLength != 0)
                error += $"must be a string with a minimum length of {MinLength}.";
            else
                error += $"must be a string with a maximum length of {MaxLength}.";

            return new ValidationResult(error);
        }
    }
}
