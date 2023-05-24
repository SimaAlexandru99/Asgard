// <copyright file="StartsWithRule18.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Validations
{
    using System.Globalization;
    using System.Windows.Controls;

    public class StartsWithRule18 : ValidationRule
    {
        public string StartsWith { get; set; } = "18";

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
