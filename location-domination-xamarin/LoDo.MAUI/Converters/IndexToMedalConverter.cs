using System.Globalization;

namespace LoDo.MAUI.Converters;

public class IndexToMedalConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        switch ((int)value)
        {
            case 1:
                return "medal_first.svg";
            break;
            case 2:
                return "medal_second.svg";
            break;
            case 3:
                return "medal_third.svg";
            default:
                return new FontImageSource()
                {
                    FontFamily = "RalewayRegular",
                    Glyph = ((int)value).ToString(),
                    Color = Color.FromHex("#E1E7E0")
                };
                return null;
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
} 