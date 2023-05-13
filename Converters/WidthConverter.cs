using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Asgard.Converters
{
    public class WidthConverter : IValueConverter
    {
        private const double InitialWidth = 100; // Initial width of the button
        private const double WidthPercentage = 0.2; // Percentage of the display width to use for the button width

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double displayWidth = (double)value;
            double displayHeight = SystemParameters.PrimaryScreenHeight;
            double buttonWidth = displayWidth * WidthPercentage; // Calculate button width as a percentage of display width

            if (displayHeight < 768)
            {
                // Decrease the button width if the display height is below the threshold
                buttonWidth *= 0; // Reduce the button width by 20%
            }
            else if (displayHeight > 768)
            {
                // Decrease the button width if the display height is below the threshold
                buttonWidth *= 0.8; // Reduce the button width by 20%
            }

            buttonWidth = Math.Max(buttonWidth, InitialWidth); // Set the minimum button width
            return buttonWidth;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
