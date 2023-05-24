// <copyright file="MarginConverter.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double height = (double)value;
            double margin = System.Convert.ToDouble(parameter);

            if (height < 500)
            {
                return new Thickness(margin + 20, 0, margin + 20, 0);
            }
            else if (height == 600)
            {
                return new Thickness(margin + 25, 0, margin + 25, 0);
            }
            else if (height < 750)
            {
                return new Thickness(margin + 35, 0, margin + 35, 0);
            }
            else if (height < 850)
            {
                return new Thickness(margin + 45, 0, margin + 45, 0);
            }
            else if (height < 1000)
            {
                return new Thickness((margin * 2) + 30, 0, (margin * 2) + 30, 0);
            }
            else
            {
                return new Thickness((margin * 3) + 10, 0, (margin * 3) + 10, 0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
