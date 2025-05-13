using LoDo.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UraniumUI.Icons.MaterialIcons;

namespace LoDo.MAUI.Converters
{
    public class IconConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var sport = value as Sport;
            try
            {
                switch (sport.Id)
                {
                    case 5:
                        return MaterialOutlined.Sports_tennis;
                    default:
                        return MaterialRegular.No_photography;
                }
            }
            catch (Exception ex)
            {
                return MaterialRegular.No_photography;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
