// <copyright file="StartsWithRule8.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Asgard.Validations
{
    using System.Globalization;
    using System.Windows.Controls;

    internal class StartsWithRule8 : ValidationRule
    {
        private readonly string startsWith = "8";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (charString.StartsWith(startsWith))
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, $"ID-ul de propunere trebuie sa inceapa cu {startsWith}");
        }
    }
}
