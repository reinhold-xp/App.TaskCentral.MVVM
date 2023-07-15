using System;
using System.Globalization;

namespace Tasker.Converters
{
    // Convertisseur de valeur / data binding (IValueConverter)
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value.ToString();
            return Color.FromArgb(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

