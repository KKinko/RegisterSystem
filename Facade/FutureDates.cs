using System.ComponentModel.DataAnnotations;

namespace RegisterSystem.Facade
{
    public class FutureDates : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Kuupäev peab olema tulevikus";
        }

        protected override ValidationResult? IsValid(object objValue,ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();


            if (dateValue.Date < DateTime.Now)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}
