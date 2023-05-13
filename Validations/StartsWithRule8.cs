using System.Globalization;
using System.Windows.Controls;

namespace Asgard.Validations
{
    class StartsWithRule8 : ValidationRule
    {
        public string StartsWith = "8";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (charString.StartsWith(StartsWith))
                return new ValidationResult(true, null);

            return new ValidationResult(false, $"ID-ul de propunere trebuie sa inceapa cu {StartsWith}");
        }
    }
}
