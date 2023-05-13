using System.Globalization;
using System.Windows.Controls;

namespace Asgard.Validations
{
    class StartsWithRule2 : ValidationRule
    {
        public string StartsWith { get; set; } = "2";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string charString && charString.StartsWith(StartsWith))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, $"ID-ul comenzii trebuie să înceapă cu '{StartsWith}'.");
        }
    }

}
