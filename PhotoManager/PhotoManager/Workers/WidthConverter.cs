using System;
using System.Globalization;
using System.Windows.Data;

namespace PhotoManager.Workers
{
    class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            if (parameter == null)
                parameter = 1;


            return double.TryParse(value.ToString(), out double number) && double.TryParse(parameter.ToString(), out double coefficient)
                ? number * coefficient / 100
                : (object)0;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
