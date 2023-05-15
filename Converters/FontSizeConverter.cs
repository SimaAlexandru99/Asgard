// <copyright file="FontSizeConverter.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class FontSizeConverter : IValueConverter
    {
        private const double InitialFontSize = 8.0;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double fontSize = InitialFontSize;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

            if (screenHeight >= 1080)
            {
                // Increase font size by 4 points for screens with height of 1080 pixels or more
                fontSize += 4;
            }

            return fontSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
