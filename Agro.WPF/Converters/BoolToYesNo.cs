using System;
using System.Globalization;
using System.Windows.Data;


namespace Agro.WPF.Converters;
public class BoolToYesNo : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((bool)value)
        {
            return "Да";
        }
        else
        {
            return "Нет";
        }

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((string)value=="Да")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}