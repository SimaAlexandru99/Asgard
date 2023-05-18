// <copyright file="StartsWithRule7.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Validations
{
    using System.Globalization;
    using System.Windows.Controls;

    internal class StartsWithRule7 : ValidationRule
    {
        public string StartsWith { get; set; } = "7";

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