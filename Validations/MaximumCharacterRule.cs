using System.Globalization;
using System.Windows.Controls;

namespace Asgard.Validations
{
    class MaximumCharacterRule : ValidationRule
    {
        public int MaximumCharacters { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!(value is string charString))
            {
                return new ValidationResult(false, "Valoarea introdusa trebuie sa fie un sir de caractere.");
            }

            if (string.IsNullOrEmpty(charString))
            {
                return new ValidationResult(false, "Șirul de caractere introdus nu poate fi nul sau gol.");
            }

            if (charString.Length > MaximumCharacters)
            {
                return new ValidationResult(false, $"Vă rugăm să introduceți maximum {MaximumCharacters} caractere.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
