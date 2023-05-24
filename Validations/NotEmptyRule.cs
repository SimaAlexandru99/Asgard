// <copyright file="NotEmptyRule.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Validations
{
    using System.Globalization;
    using System.Windows.Controls;

    public class NotEmptyRule : ValidationRule
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
