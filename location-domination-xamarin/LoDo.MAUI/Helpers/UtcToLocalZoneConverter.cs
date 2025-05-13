using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Helpers
{
    public class UtcToLocalZoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case null:
                    return null;
                case DateTime time:
                    return time.ToLocalTime();
                default:
                    return DateTime.Parse(value?.ToString()).ToLocalTime();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case null:
                    return null;
                case DateTime time:
                    return time.ToUniversalTime();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
