using System.Globalization;
using System.Windows.Controls;

namespace Asgard.Validations
{
    class StartsWithRule07 : ValidationRule
    {
        public string StartsWith { get; set; } = "07";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string charString && charString.StartsWith(StartsWith))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, $"Numărul trebuie să înceapă cu '{StartsWith}'.");
        }
    }

}
