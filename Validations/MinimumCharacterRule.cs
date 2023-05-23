// <copyright file="MinimumCharacterRule.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Validations
{
    using System.Globalization;
    using System.Windows.Controls;

    public class MinimumCharacterRule : ValidationRule
    {
        public int MinimumCharacters { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value as string))
            {
                return new ValidationResult(false, "Te rog să introduci minim {MinimumCharacters}  caractere.");
            }

            if (((string)value).Length < MinimumCharacters)
            {
                return new ValidationResult(false, $"Te rog să introduci minim {MinimumCharacters} caractere.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
