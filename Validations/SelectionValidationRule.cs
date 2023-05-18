// <copyright file="SelectionValidationRule.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Validations
{
    using System.Windows.Controls;

    public class SelectionValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            return value == null
                ? new ValidationResult(false, "Please select one")
                : new ValidationResult(true, null);
        }
    }
}
