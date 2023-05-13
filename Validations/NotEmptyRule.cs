﻿using System.Globalization;
using System.Windows.Controls;

namespace Asgard.Validations
{
    class NotEmptyRule : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string charString && !string.IsNullOrWhiteSpace(charString))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Câmpul nu trebuie să fie gol");
        }

    }
}
