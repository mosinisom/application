using System;
using Avalonia.Data.Converters;
using System.Globalization;

namespace application.Converter
{

    public class StringToDateTimeConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string date)
            {
                return DateTime.ParseExact(date, "dd.MM.yyyy H:mm:ss zzz", CultureInfo.InvariantCulture);
            }


            return null;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                return date.ToString("dd.MM.yyyy H:mm:ss zzz");
            }

            return null;
        }
    }
}